using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.BlockChain;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repos
{
    public class CarSalesRepository : ICarSalesRepository
    {
        private readonly CarSalesContext _context;

        public CarSalesRepository(CarSalesContext context)
        {
            _context = context;
        }

        public async Task<IList<CarEntry>> GetCars()
        {
            return await _context.CarEntries.ToListAsync();
        }

        public async Task<CarEntry> GetCar(int id)
        {
            var car = await _context.CarEntries
                .Include(c => c.CarSalesEntries)
                .SingleOrDefaultAsync(c => c.Id == id);

            if (car != null)
            {
                BlockChainHelper.VerifyBlockChain(car.CarSalesEntries);
            }

            return car;
        }

        public async Task CreateCar(CarEntry car)
        {
            if (car == null)
                throw new ArgumentNullException(nameof(car));

            car.CreateDate = DateTimeOffset.UtcNow;

            _context.CarEntries.Add(car);

            await _context.SaveChangesAsync();
        }

        public async Task CreateCarSale(CarSalesEntry carSalesEntry)
        {
            if (carSalesEntry == null)
                throw new ArgumentNullException(nameof(carSalesEntry));

            var carSalesEntries = await _context.CarSalesEntries.Where(c => c.CarEntryId == carSalesEntry.CarEntryId).ToListAsync();

            BlockChainHelper.VerifyBlockChain(carSalesEntries);
            if (carSalesEntries.Any(c => !c.IsValid))
            {
                throw new InvalidOperationException( "Block Chain was invalid");
            }

            string previousBlockHash = null;
            if (carSalesEntries.Any())
            {
                var previousCarSalesEntry = carSalesEntries.Last();
                carSalesEntry.PreviousId = previousCarSalesEntry.Id;
                previousBlockHash = previousCarSalesEntry.Hash;
            }

            var blockText = BlockHelper.ConcatData(carSalesEntry.CarEntryId, carSalesEntry.CarNumber,
                carSalesEntry.Price, carSalesEntry.TransactionDate, previousBlockHash);
            carSalesEntry.Hash = HashHelper.Hash(blockText);

            _context.CarSalesEntries.Add(carSalesEntry);

            await _context.SaveChangesAsync();
        }
    }
}