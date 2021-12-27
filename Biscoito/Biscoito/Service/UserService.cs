using Biscoito.ViewModel;
using Biscoito.WebService;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Biscoito.Service
{

    public interface IUserService
    {
        Task<bool> Login(string email, string password);
    }

    public class UserService : IUserService
    {

        private readonly IWebClientOptionsService _webClientOptions;

        public UserService()
        {
            _webClientOptions = DependencyService.Resolve<IWebClientOptionsService>();
        }

        public async Task<bool> Login(string email, string password)
        {
            try
            {
                var webService = RestService.For<IWebServiceUserService>(_webClientOptions.GetBaseUrl());
                var result = await webService.Login(new UserLogin()
                {
                    Email = email,
                    Password = password
                });

                return result;
            }
            catch (Exception e)
            {
                var erro = e.Message;
                return string.IsNullOrEmpty(erro);
            }
        }
    }
}
