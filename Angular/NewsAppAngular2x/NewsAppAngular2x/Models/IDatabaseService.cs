namespace NewsAppAngular2x.Models
{
    public interface IDatabaseService
    {
        void ClearAll();
        void RecreateDatabase();
        void SeedRepo();
    }
}