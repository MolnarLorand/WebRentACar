using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentACar.Models
{
    public class Category
    {
        public int ID { get; set; }

        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Numele Categoriei trebuie sa fie de forma 'Categorie'"), Required, StringLength(50, MinimumLength = 3)]
        public string CategoryName { get; set; }

        public ICollection<CarCategory> CarCategories { get; set; }
    }
}
