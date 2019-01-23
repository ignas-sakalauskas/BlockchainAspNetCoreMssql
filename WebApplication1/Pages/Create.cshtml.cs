using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Repos;

namespace WebApplication1.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ICarSalesRepository _repository;

        public CreateModel(ICarSalesRepository repository)
        {
            _repository = repository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CarEntry CarEntry { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _repository.CreateCar(CarEntry);

            return RedirectToPage("./Index");
        }
    }
}