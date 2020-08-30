using Cotacao.Service.Models;
using System.Threading.Tasks;

namespace Cotacao.Service.Interfaces
{
    public interface IStockQuotesWinService
    {
        Task Start(StockQuotesArguments arguments);
        void Stop();
    }
}
