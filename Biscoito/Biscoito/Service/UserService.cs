using Biscoito.WebService;
using DTO;
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
                return await webService.Login(new UserLoginDTO()
                {
                    Email = email,
                    Password = password
                });
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
