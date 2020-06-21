using Daroya.MoneymeAPI.Database.Repository;
using Daroya.MoneymeAPI.Models.Models.DTO;
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
                response.RedirectUrl = _configService.GetWebAppUrl() + "quote/calculator?id=" + newQuoteId.ToString();
            }
            catch(Exception e)
            {
                response.IsSuccess = false;
                response.ErrorMessage = e.Message;
            }
            return response;
        }

        public EditQuoteAndSaveResponse EditQuoteAndSave(EditQuoteAndSaveRequest request)
        {
            var response = new EditQuoteAndSaveResponse();
            try
            {
                if (request?.Quote?.Id != null)
                {
                    _quoteRepository.EditQuoteAndSave(request.Quote);
                    response.IsSuccess = true;
                }
                else
                {
                    throw new Exception(string.Format("Error updating quote"));
                }
            }
            catch (Exception e)
            {
                response.IsSuccess = false;
                response.ErrorMessage = e.Message;
            }
            return response;

        }

        public GetQuoteResponse GetQuote(Guid id)
        {
            var response = new GetQuoteResponse();
            try
            {
                response.Quote = _quoteRepository.GetQuote(id);
                if (response.Quote == null)
                {
                    throw new Exception(string.Format("Error loading quote with id {0}", id));
                }
                response.IsSuccess = true;
            }
            catch (Exception e)
            {
                response.IsSuccess = false;
                response.ErrorMessage = e.Message;
            }
            return response;
        }

        
    }
}
