using System.Collections.Generic;

namespace NewsAppAngular2x.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Category GetById(int newsCategoryId);
    }
}
