using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebRentACar.Data;
using WebRentACar.Models;

namespace WebRentACar.Pages.Producers
{
    public class DeleteModel : PageModel
    {
        private readonly WebRentACar.Data.WebRentACarContext _context;

        public DeleteModel(WebRentACar.Data.WebRentACarContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Producer Producer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Producer = await _context.Producer.FirstOrDefaultAsync(m => m.ID == id);

            if (Producer == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Producer = await _context.Producer.FindAsync(id);

            if (Producer != null)
            {
                _context.Producer.Remove(Producer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
