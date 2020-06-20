using Daroya.MoneymeAPI.Models.Requests;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Daroya.MoneymeAPI.Models.Models.Requests.Validators
{
    public static class ConfigureValidators
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddSingleton<IValidator<CreateQuoteRequest>, CreateQuoteRequestValidator>();
        }
    }
}
