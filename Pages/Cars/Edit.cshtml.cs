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

namespace WebRentACar.Pages.Cars
{
    public class EditModel : CarCategoriesPageModel
    {
        private readonly WebRentACar.Data.WebRentACarContext _context;

        public EditModel(WebRentACar.Data.WebRentACarContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Car Car { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car = await _context.Car
              .Include(b => b.Producer)
              .Include(b => b.CarCategories).ThenInclude(b => b.Category)
              .AsNoTracking()
              .FirstOrDefaultAsync(m => m.ID == id);

            if (Car == null)
            {
                return NotFound();
            }

            PopulateAssignedCategoryData(_context, Car);

            ViewData["ProducerID"] = new SelectList(_context.Set<Producer>(), "ID", "ProducerName");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
        selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var carToUpdate = await _context.Car
            .Include(i => i.Producer)
            .Include(i => i.CarCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (carToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Car>(
            carToUpdate,
            "Car",
            i => i.Model, i => i.Color,
            i => i.PlateNumber, i => i.DayPrice, i => i.ProductionDate, i => i.ProducerID))//?producer
            {
                UpdateCarCategories(_context, selectedCategories, carToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            

            UpdateCarCategories(_context, selectedCategories, carToUpdate);
            PopulateAssignedCategoryData(_context, carToUpdate);
            return Page();
        }

    private bool CarExists(int id)
        {
            return _context.Car.Any(e => e.ID == id);
        }
    }
}
