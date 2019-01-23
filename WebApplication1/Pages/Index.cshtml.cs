using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Repos;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICarSalesRepository _repository;

        public IndexModel(ICarSalesRepository repository)
        {
            _repository = repository;
        }

        public IList<CarEntry> Cars { get; set; }

        public async Task OnGetAsync()
        {
            Cars = await _repository.GetCars();
        }
    }
}
