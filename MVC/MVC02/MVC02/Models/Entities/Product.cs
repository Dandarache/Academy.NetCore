using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc02.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Obligatoriskt")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Obligatoriskt")]
        [Range(0, 1000, ErrorMessage = "Måste va mellan 0 och 1000")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public bool ForSale { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; } // Används i vyn  av select-boxen
    }
}
