using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.BlockChain
{
    public static class BlockChainHelper
    {
        public static void VerifyBlockChain(IList<CarSalesEntry> carSalesEntries)
        {
            string previousHash = null;
            foreach (var entry in carSalesEntries.OrderBy(c => c.Id))
            {
                var previousBlock = carSalesEntries.SingleOrDefault(c => c.Id == entry.PreviousId);
                var blockText = BlockHelper.ConcatData(
                    entry.CarEntryId,
                    entry.CarNumber,
                    entry.Price,
                    entry.TransactionDate,
                    previousHash);

                var blockHash = HashHelper.Hash(blockText);

                // check current block hashes, and previous block hashes, since
                // it could have been modified in DB, ie checking the chain by two blocks at a time
                entry.IsValid = blockHash == entry.Hash && previousHash == previousBlock?.Hash;

                previousHash = blockHash;
            }
        }
    }
}
