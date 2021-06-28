using Biscoito.Properties;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biscoito.Service
{

    public interface IResourceService
    {
        string GetText(string key);
    }

    public class ResourceService : IResourceService
    {
        public string GetText(string key)
        {
            return Resources.ResourceManager.GetString(key);
        }

    }
}
