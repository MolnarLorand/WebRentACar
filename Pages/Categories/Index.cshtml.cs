using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebRentACar.Data;
using WebRentACar.Models;

namespace WebRentACar.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly WebRentACar.Data.WebRentACarContext _context;

        public IndexModel(WebRentACar.Data.WebRentACarContext context)
        {
            _context = context;
        }

        public IList<CarCategory> CarCategory { get;set; }

        public async Task OnGetAsync()
        {
            CarCategory = await _context.CarCategory
                .Include(c => c.Car)
                .Include(c => c.Category).ToListAsync();
        }
    }
}
