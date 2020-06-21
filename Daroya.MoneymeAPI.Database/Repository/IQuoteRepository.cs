using Daroya.MoneymeAPI.Models.Models.DTO;
using System;


namespace Daroya.MoneymeAPI.Database.Repository
{
    public interface IQuoteRepository
    {
        QuoteDTO GetQuote(Guid quoteId);
        Guid CreateQuote(QuoteDTO newQuote);
        void EditQuoteAndSave(QuoteDTO quote);
    }
}
