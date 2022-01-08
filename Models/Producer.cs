using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentACar.Models
{
    public class Producer
    {
        public int ID { get; set; }

        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Numele producatorului trebuie sa fie de forma 'Producator'"), Required,StringLength(50, MinimumLength = 3)]
        public string ProducerName { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
