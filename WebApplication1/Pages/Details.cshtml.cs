using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Repos;

namespace WebApplication1.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly ICarSalesRepository _repository;

        public DetailsModel(ICarSalesRepository repository)
        {
            _repository = repository;
        }

        public CarEntry CarEntry { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _repository.GetCar(id.Value);
            if (car == null)
            {
                return NotFound();
            }

            CarEntry = car;

            return Page();
        }
    }
}
