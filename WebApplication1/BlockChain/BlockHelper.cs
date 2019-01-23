using System;

namespace WebApplication1.BlockChain
{
    public static class BlockHelper
    {
        public static string ConcatData(int carEntryId, string carNumber, decimal price, DateTimeOffset transactionDate, string previousBlockHash)
        {
            var formattedPrice = price.ToString("F");
            var formattedDate = transactionDate.ToString("yyyy-MM-dd");
            return $"{carEntryId}{carNumber}{formattedPrice}{formattedDate}{previousBlockHash}";
        }
    }
}
