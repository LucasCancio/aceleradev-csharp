using Codenation.Challenge.Models;

namespace Source.Util.Extensions
{
    public static class QuoteExtensions
    {
        public static QuoteView ToQuoteView(this Quote quote)
        {
            return new QuoteView() { Actor = quote.Actor, Detail = quote.Detail, Id = quote.Id };
        }
    }
}
