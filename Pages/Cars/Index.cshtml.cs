using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebRentACar.Data;
using WebRentACar.Models;

namespace WebRentACar.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly WebRentACar.Data.WebRentACarContext _context;

        public IndexModel(WebRentACar.Data.WebRentACarContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get;set; }

        public async Task OnGetAsync()
        {
            Car = await _context.Car.Include(b=>b.Producer).ToListAsync();
        }
    }
}
