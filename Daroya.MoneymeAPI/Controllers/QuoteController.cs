using System;
using System.Linq;
using Daroya.MoneymeAPI.Models.Models.Responses;
using Daroya.MoneymeAPI.Models.Requests;
using Daroya.MoneymeAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Daroya.MoneymeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class QuoteController : ControllerBase
    {
        private readonly ILogger<QuoteController> _logger;
        private readonly IQuoteService _quoteService;

        public QuoteController(ILogger<QuoteController> logger, IQuoteService quoteService)
        {
            _logger = logger;
            _quoteService = quoteService;
        }

        [HttpPost]
        public CreateQuoteResponse CreateQuote(CreateQuoteRequest request)
        {
            return _quoteService.CreateQuote(request);
        }

        [HttpGet]
        public GetQuoteResponse GetQuote(Guid quoteId)
        {
            return _quoteService.GetQuote(quoteId);
        }
    }
}
