namespace EfSamurai.Domain.Entities
{
    public class SamuraiBattle
    {
        public Samurai Samurai { get; set; }
        public int SamuraiId { get; set; }

        public Battle Battle { get; set; }
        public int BattleId { get; set; }
    }
}
