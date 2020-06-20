using System;
using System.Collections.Generic;
using System.Text;

namespace Daroya.MoneymeAPI.Models.Models.Responses
{
    public class CreateQuoteResponse
    {
        public string RedirectUrl { get; set; }
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }
}
