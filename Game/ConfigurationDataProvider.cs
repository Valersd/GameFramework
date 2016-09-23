using System;
using System.Configuration;

namespace Game
{
    public class ConfigurationDataProvider : IConfigurationDataProvider
    {
        public string Get(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
