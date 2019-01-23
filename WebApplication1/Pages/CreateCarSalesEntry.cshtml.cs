using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Repos;

namespace WebApplication1.Pages
{
    public class CreateCarSalesEntryModel : PageModel
    {
        private readonly ICarSalesRepository _repository;

        public CreateCarSalesEntryModel(ICarSalesRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> OnGet(int? carId)
        {
            if (carId == null)
            {
                return NotFound();
            }

            var car = await _repository.GetCar(carId.Value);
            if (car == null)
            {
                return NotFound();
            }

            CarEntry = car;

            return Page();
        }

        public CarEntry CarEntry { get; set; }

        [BindProperty]
        public CarSalesEntry CarSalesEntry { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _repository.CreateCarSale(CarSalesEntry);

            return RedirectToPage("Details", new { id = CarSalesEntry.CarEntryId });
        }
    }
}