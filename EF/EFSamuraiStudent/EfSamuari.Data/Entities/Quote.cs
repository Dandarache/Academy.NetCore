namespace EfSamurai.Domain.Entities
{
    public class Quote
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public Samurai Samurai { get; set; }
        public int SamuraiId { get; set; }

        public QuoteStyle? Style { get; set; }
    }
}
