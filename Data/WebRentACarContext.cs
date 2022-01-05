using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebRentACar.Models;

namespace WebRentACar.Data
{
    public class WebRentACarContext : DbContext
    {
        public WebRentACarContext (DbContextOptions<WebRentACarContext> options)
            : base(options)
        {
        }

        public DbSet<WebRentACar.Models.Car> Car { get; set; }

        public DbSet<WebRentACar.Models.Producer> Producer { get; set; }

        //public DbSet<WebRentACar.Models.CarCategory> CarCategory { get; set; }

        public DbSet<WebRentACar.Models.Category> Category { get; set; }

    }
}
