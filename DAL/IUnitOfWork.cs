using DAL.Services;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUnitOfWork
    {
        // repository goes here
       ITransactionRepo TransactionRepo { get; }
       ICustomerRepo CustomerRepo { get; }
       ICurrentAccountRepo CurrentAccountRepo { get; }
       
     
        void Save();
        Task SaveAsync();
    }
}
