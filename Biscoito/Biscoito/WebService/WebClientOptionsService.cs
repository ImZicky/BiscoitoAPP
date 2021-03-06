using System;
using System.Collections.Generic;
using System.Text;

namespace Biscoito.WebService
{

    public interface IWebClientOptionsService
    {
        string GetBaseUrl();
    }

    public class WebClientOptionsService : IWebClientOptionsService
    {
        private readonly string _baseUrl;

        public WebClientOptionsService()
        {
            _baseUrl = "https://localhost:44330/api/v1/";
        }

        public string GetBaseUrl()
        {
           return _baseUrl;
        }
    }
}
