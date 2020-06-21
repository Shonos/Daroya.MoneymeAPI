using Daroya.MoneymeAPI.Models.Models.DTO;
using Daroya.MoneymeAPI.Models.Models.Responses;
using Daroya.MoneymeAPI.Models.Requests;
using System;

namespace Daroya.MoneymeAPI.Services
{
    public interface IQuoteService
    {
        CreateQuoteResponse CreateQuote(CreateQuoteRequest request);
        GetQuoteResponse GetQuote(Guid id);
        EditQuoteAndSaveResponse EditQuoteAndSave(EditQuoteAndSaveRequest request);
    }
}
