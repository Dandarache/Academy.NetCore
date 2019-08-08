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
        [Range(10000, 1000000, ErrorMessage = "Måste vara mellan 10000 och 1000000 kronor")]
        [Column(TypeName = "decimal(18,2)")]                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    
        public decimal Price { get; set; }

        public bool ForSale { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; } // Används i vyn  av select-boxen
    }
}
