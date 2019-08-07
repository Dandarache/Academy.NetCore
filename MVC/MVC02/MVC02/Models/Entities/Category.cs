using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mvc02.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Category name")]
        public string Name { get; set; }
    }
}

