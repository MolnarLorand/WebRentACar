using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentACar.Models
{
    public class Producer
    {
        public int ID { get; set; }

        public string ProducerName { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
