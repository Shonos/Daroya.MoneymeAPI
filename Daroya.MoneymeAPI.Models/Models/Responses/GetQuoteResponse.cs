using Daroya.MoneymeAPI.Models.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Daroya.MoneymeAPI.Models.Models.Responses
{
    public class GetQuoteResponse
    {
        public QuoteDTO Quote { get; set; }
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }
}
