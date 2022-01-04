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
    public class DetailsModel : PageModel
    {
        private readonly WebRentACar.Data.WebRentACarContext _context;

        public DetailsModel(WebRentACar.Data.WebRentACarContext context)
        {
            _context = context;
        }

        public CarCategory CarCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CarCategory = await _context.CarCategory
                .Include(c => c.Car)
                .Include(c => c.Category).FirstOrDefaultAsync(m => m.ID == id);

            if (CarCategory == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
