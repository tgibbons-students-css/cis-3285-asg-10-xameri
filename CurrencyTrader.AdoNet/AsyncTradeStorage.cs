using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrencyTrader.Contracts;

namespace CurrencyTrader.AdoNet
{
    public class AsyncTradeStorage : ITradeStorage
    {

        private readonly ILogger logger;
        private ITradeStorage SyngTradeStorage;

        public AsyncTradeStorage(ILogger logger)
        {
            this.logger = logger;
            SyngTradeStorage = new AdoNetTradeStorage(logger);
        }

        public void Persist(IEnumerable<TradeRecord> trades)
        {
            logger.LogInfo("Starting synch trade storage");
            // SyngTradeStorage.Persist(trades);
            Task.Run(() => SyngTradeStorage.Persist(trades));
        }
    }
}
