using Daroya.MoneymeAPI.Models.Models.DTO;
using Daroya.MoneymeAPI.Models.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Daroya.MoneymeAPI.Database.Repository
{
    public class QuoteRepository : IQuoteRepository
    {
        private readonly MoneyMeContext _moneyMeContext;
        public QuoteRepository(MoneyMeContext moneyMeContext)
        {
            _moneyMeContext = moneyMeContext;
        }

        public Guid CreateQuote(QuoteDTO newQuote)
        {
            try
            {
                if (newQuote != null)
                {
                    var quote = new Quote()
                    {
                        Email = newQuote.Email,
                        FirstName = newQuote.FirstName,
                        LastName = newQuote.LastName,
                        Mobile = newQuote.Mobile,
                        Term = newQuote.Term,
                        Title = newQuote.Title,
                        Amount = newQuote.Amount,
                        CreatedDate = DateTime.UtcNow,
                        CreatedByName = "SYSTEM",
                        LastUpdatedDate = DateTime.UtcNow,
                        LastUpdatedBy = Guid.Empty,
                        LastUpdatedByName = "SYSTEM"
                    };
                    _moneyMeContext.Quotes.Add(quote);
                    _moneyMeContext.SaveChanges();

                    CheckLimitQuoteRecordsInDb();

                    return quote.Id;
                }
                throw new Exception(string.Format("Creating quote for {0} {1}", newQuote.FirstName, newQuote.LastName));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public QuoteDTO GetQuote(Guid quoteId)
        {
            QuoteDTO quoteDTO = new QuoteDTO();
            if (quoteId != null)
            {
                quoteDTO = _moneyMeContext.Quotes
                            .Where(q => q.Id == quoteId)
                            .Select(q => new QuoteDTO()
                            {
                                Id = q.Id,
                                Email = q.Email,
                                FirstName = q.FirstName,
                                LastName = q.LastName,
                                Mobile = q.Mobile,
                                Term = q.Term,
                                Title = q.Title,
                                Amount = q.Amount
                            }).FirstOrDefault();
            }

            return quoteDTO;
        }

        // DEPLOYING APP ON SERVER, MAKING SURE TO LIMIT RECORDS ON SQL LITE
        private void CheckLimitQuoteRecordsInDb()
        {
            if (_moneyMeContext.Quotes.Count() > 100)
            {
                var quoteToDelete = _moneyMeContext.Quotes.OrderBy(m => m.CreatedDate).FirstOrDefault();
                _moneyMeContext.Quotes.Remove(quoteToDelete);
                _moneyMeContext.SaveChanges();
            }
        }


    }
}
