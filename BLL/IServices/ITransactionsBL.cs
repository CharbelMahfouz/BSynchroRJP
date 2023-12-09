using System.Threading.Tasks;

namespace BLL.IServices
{
    public interface ITransactionsBL
    {
        Task CreateTransaction(decimal amount, decimal oldBalance, decimal newBalance, int accountId);
    }
}