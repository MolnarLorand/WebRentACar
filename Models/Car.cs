using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebRentACar.Models
{
    public class Car
    {
        public int ID { get; set; }

        [Display(Name = "Car Model")]
        public string Model { get; set; }

        public string Color { get; set; }

        [Display(Name = "Plate Number")]
        public string PlateNumber { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal DayPrice { get; set; }

        [DataType(DataType.Date)]
        public DateTime ProductionDate { get; set; }

        public int ProducerID { get; set; }
        public Producer Producer { get; set; }

        public ICollection<CarCategory> CarCategories { get; set; }

    }
}
