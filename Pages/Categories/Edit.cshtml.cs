using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebRentACar.Data;
using WebRentACar.Models;

namespace WebRentACar.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly WebRentACar.Data.WebRentACarContext _context;

        public EditModel(WebRentACar.Data.WebRentACarContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["CarID"] = new SelectList(_context.Car, "ID", "ID");
           ViewData["CategoryID"] = new SelectList(_context.Set<Category>(), "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CarCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarCategoryExists(CarCategory.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CarCategoryExists(int id)
        {
            return _context.CarCategory.Any(e => e.ID == id);
        }
    }
}
