using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebRentACar.Data;
using WebRentACar.Models;

namespace WebRentACar.Pages.Cars
{
    public class CreateModel : CarCategoriesPageModel
    {
        private readonly WebRentACar.Data.WebRentACarContext _context;

        public CreateModel(WebRentACar.Data.WebRentACarContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ProducerID"] = new SelectList(_context.Set<Producer>(), "ID", "ProducerName");

            var car = new Car();
            car.CarCategories = new List<CarCategory>();
            PopulateAssignedCategoryData(_context, car);

            return Page();
        }

        [BindProperty]
        public Car Car { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newCar = new Car();
            if (selectedCategories != null)
            {
                newCar.CarCategories = new List<CarCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new CarCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newCar.CarCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Car>(
            newCar,
            "Car",
            i => i.Model, i => i.Color,
            i => i.PlateNumber, i => i.DayPrice, i => i.ProductionDate, i => i.ProducerID))
            {
                _context.Car.Add(newCar);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newCar);
            return Page();
        }
    }
}
