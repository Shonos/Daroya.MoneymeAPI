using Daroya.MoneymeAPI.Models.Models.Responses;
using Daroya.MoneymeAPI.Models.Requests;
using System;

namespace Daroya.MoneymeAPI.Services
{
    public interface IConfigurationService
    {
        string GetWebAppUrl();
    }
}
