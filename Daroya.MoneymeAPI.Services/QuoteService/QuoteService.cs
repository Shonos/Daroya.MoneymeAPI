using Daroya.MoneymeAPI.Database.Repository;
using Daroya.MoneymeAPI.Models.Models.Responses;
using Daroya.MoneymeAPI.Models.Requests;
using System;

namespace Daroya.MoneymeAPI.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly IQuoteRepository _quoteRepository;
        private readonly IConfigurationService _configService;

        public QuoteService(IQuoteRepository quoteRepository, IConfigurationService configService)
        {
            _quoteRepository = quoteRepository;
            _configService = configService;
        }
        public CreateQuoteResponse CreateQuote(CreateQuoteRequest request)
        {
            CreateQuoteResponse response = new CreateQuoteResponse() { };
            try
            {
                var newQuoteId = _quoteRepository.CreateQuote(request.Quote);
                response.IsSuccess = true;
                response.RedirectUrl = _configService.GetWebAppUrl() + "quote?id=" + newQuoteId.ToString();
            }
            catch(Exception e)
            {
                response.IsSuccess = false;
                response.ErrorMessage = e.Message;
            }
            return response;
        }
    }
}
