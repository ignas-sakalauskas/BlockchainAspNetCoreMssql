using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repos
{
    public interface ICarSalesRepository
    {
        Task<IList<CarEntry>> GetCars();
        Task<CarEntry> GetCar(int id);
        Task CreateCar(CarEntry carEntry);
        Task CreateCarSale(CarSalesEntry carSalesEntry);
    }
}
