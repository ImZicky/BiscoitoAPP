using DTO;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Biscoito.WebService
{

    public interface IWebServiceUserService
    {
        [Post("/login")]
        Task<bool> Login([Body] UserLoginDTO userLoginDTO);


    }
}
