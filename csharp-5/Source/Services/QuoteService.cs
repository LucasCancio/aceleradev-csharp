using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class QuoteService : IQuoteService
    {
        private ScriptsContext _context;
        private IRandomService _randomService;


        public QuoteService(ScriptsContext context, IRandomService randomService)
        {
            this._context = context;
            this._randomService = randomService;
        }

        public Quote GetAnyQuote()
        {
            List<Quote> quotes = GetAllQuotes();

            if (quotes is null || quotes.Count == 0) return null;

            int randomPosition = _randomService.RandomInteger(quotes.Count - 1);

            return quotes[randomPosition];
        }

        public Quote GetAnyQuote(string actor)
        {
            List<Quote> quotesByActor = GetAllQuotesByActor(actor);

            if (quotesByActor is null || quotesByActor.Count == 0) return null;

            int randomPosition = _randomService.RandomInteger(quotesByActor.Count - 1);

            return quotesByActor[randomPosition];
        }

        private List<Quote> GetAllQuotesByActor(string actor)
        {
            return _context.Quotes
                .Where(q => q.Actor.ToLower().Replace(" ", "") == actor.ToLower().Replace(" ", ""))
                .ToList();
        }

        private List<Quote> GetAllQuotes()
        {
            return _context.Quotes.ToList();
        }
    }
}