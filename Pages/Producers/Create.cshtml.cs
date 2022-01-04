using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebRentACar.Data;
using WebRentACar.Models;

namespace WebRentACar.Pages.Producers
{
    public class CreateModel : PageModel
    {
        private readonly WebRentACar.Data.WebRentACarContext _context;

        public CreateModel(WebRentACar.Data.WebRentACarContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Producer Producer { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Producer.Add(Producer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
