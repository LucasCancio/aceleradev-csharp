using System;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;
using Source.Util.Extensions;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        private readonly IQuoteService _service;

        public QuoteController(IQuoteService service)
        {
            _service = service;
        }

        // GET api/quote
        [HttpGet]
        public ActionResult<QuoteView> GetAnyQuote()
        {
            try
            {
                Quote quote = _service.GetAnyQuote();
                if (quote is null) return NotFound();
                return quote.ToQuoteView();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro no sistema: {ex.Message}");
            }
        }

        // GET api/quote/{actor}
        [HttpGet("{actor}")]
        public ActionResult<QuoteView> GetAnyQuote(string actor)
        {
            try
            {
                Quote quote = _service.GetAnyQuote(actor);
                if (quote is null) return NotFound();
                return quote.ToQuoteView();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro no sistema: {ex.Message}");
            }
        }

    }
}
