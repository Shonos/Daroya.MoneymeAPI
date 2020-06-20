using Daroya.MoneymeAPI.Models.Models.Responses;
using Daroya.MoneymeAPI.Models.Requests;
using Microsoft.Extensions.Configuration;
using System;

namespace Daroya.MoneymeAPI.Services
{
    public class ConfigurationService : IConfigurationService
    {
        IConfiguration _config;
        public ConfigurationService(IConfiguration config)
        {
            _config = config;
        }

        public string GetWebAppUrl()
        {
            return _config.GetSection("ApplicationSettings")["WebAppUrl"].ToLower();
        }
    }
}
