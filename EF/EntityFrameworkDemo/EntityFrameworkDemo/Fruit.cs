using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityFrameworkDemo
{
    [Table("Frukterna")]
    public class Fruit : IEntity
    {
        public int Id { get; set; }

        [Required] // NOT NULL
        [StringLength(50)] // NVARCHAR(50)
        //[StringLength(50, MinimumLength = 2)] // NVARCHAR(50)
        public string Name { get; set; }

        [Required] // NOT NULL
        public FruitColor Color { get; set; }

        [Required] // NOT NULL
        public FruitCategory Category { get; set; }

        public decimal? Price { get; set; }

        [NotMapped]
        public int DummyBusiness { get; set; }



    }
}
