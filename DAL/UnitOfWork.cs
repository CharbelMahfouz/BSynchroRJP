//using DAL.Models;
using DAL.Data;
using DAL.Services;
using DAL.Repos;
using System;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        protected readonly BSynchroRJPDbContext _context;

        public UnitOfWork(BSynchroRJPDbContext context)
        {
            _context = context;
        }



        #region private 


       
        //add private repo here
        private ITransactionRepo _transactionRepo;
        private ICustomerRepo _customerRepo;
        private ICurrentAccountRepo _currentaccountRepo;
       
 

        #endregion



        #region public 
       
        // add public repo here
        public ITransactionRepo TransactionRepo => _transactionRepo ??= new TransactionRepo(_context);
        public ICustomerRepo CustomerRepo => _customerRepo ??= new CustomerRepo(_context);
        public ICurrentAccountRepo CurrentAccountRepo => _currentaccountRepo ??= new CurrentAccountRepo(_context);
      
        

        #endregion





        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async virtual Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
