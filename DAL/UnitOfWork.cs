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
        protected readonly ChrisCellDbContext _context;

        public UnitOfWork(ChrisCellDbContext context)
        {
            _context = context;
        }



        #region private 

        //private IProfileRepos profileRepos;

        private IUserRepos userRepos;
        private INotificationRepo notificationRepository;
        private IPhoneOtpRepo phoneOtpRepo;
        private IResetPasswordRepo resetPasswordRepo;
        private IProductRepo productRepo;
        private ICategoryRepo categoryRepo;
        private ISubcategoryRepo subcategoryRepo;
        //add private repo here
        private IStockManagementRestockOrderItemRepo _stockmanagementrestockorderitemRepo;
        private IStockManagementRestockOrderRepo _stockmanagementrestockorderRepo;
        private IStockManagementInventoryRepo _stockmanagementinventoryRepo;
        private ISalesOrderTimelineRepo _salesordertimelineRepo;
        private ISalesOrderStatusRepo _salesorderstatusRepo;
        private ISalesOrderItemRepo _salesorderitemRepo;
        private ISalesOrderRepo _salesorderRepo;
        private IProfPersonRepo _profpersonRepo;
        private IProductVariationRepo _productvariationRepo;
        private IProductTempImageRepo _producttempimageRepo;
        private IProductStatusRepo _productstatusRepo;
        private IProductSoldHistoryRepo _productsoldhistoryRepo;
        private IProductImageRepo _productimageRepo;
        private IProductColorRepo _productcolorRepo;
        private IGenStockManagementRestockOrderStatusRepo _genstockmanagementrestockorderstatusRepo;
        private IGenCrmCompanyTypeRepo _gencrmcompanytypeRepo;
        private IGenCountryRepo _gencountryRepo;
        private ICrmCompanyRepo _crmcompanyRepo;
        private ICrmClientProfileRepo _crmclientprofileRepo;
        private IAspNetUserTokenRepo _aspnetusertokenRepo;
        private IAspNetUserLoginRepo _aspnetuserloginRepo;
        private IAspNetUserClaimRepo _aspnetuserclaimRepo;
        private IAspNetUserRepo _aspnetuserRepo;
        private IAspNetRoleClaimRepo _aspnetroleclaimRepo;
        private IAspNetRoleRepo _aspnetroleRepo;
        private IApiDataLoggingRepo _apidataloggingRepo;
        private IAccResetPasswordDetailRepo _accresetpassworddetailRepo;

        #endregion



        #region public 
        //public IProfileRepos ProfileRepos => profileRepos ?? new ProfileRepos(_context);
        public IUserRepos UserRepos => userRepos ?? new UserRepos(_context);
        public INotificationRepo NotificationRepository => notificationRepository ?? new NotificationRepo(_context);
        public IPhoneOtpRepo PhoneOtpRepo => phoneOtpRepo ?? new PhoneOtpRepo(_context);
        public IResetPasswordRepo ResetPasswordRepo => resetPasswordRepo ?? new ResetPasswordRepo(_context);

        public ICategoryRepo CategoryRepo => categoryRepo ?? new CategoryRepo(_context);
        public IProductRepo ProductRepo => productRepo ?? new ProductRepo(_context);
        public ISubcategoryRepo SubcategoryRepo => subcategoryRepo ?? new SubcategoryRepo(_context);
        // add public repo here
        public IStockManagementRestockOrderItemRepo StockManagementRestockOrderItemRepo => _stockmanagementrestockorderitemRepo ??= new StockManagementRestockOrderItemRepo(_context);
        public IStockManagementRestockOrderRepo StockManagementRestockOrderRepo => _stockmanagementrestockorderRepo ??= new StockManagementRestockOrderRepo(_context);
        public IStockManagementInventoryRepo StockManagementInventoryRepo => _stockmanagementinventoryRepo ??= new StockManagementInventoryRepo(_context);
        public ISalesOrderTimelineRepo SalesOrderTimelineRepo => _salesordertimelineRepo ??= new SalesOrderTimelineRepo(_context);
        public ISalesOrderStatusRepo SalesOrderStatusRepo => _salesorderstatusRepo ??= new SalesOrderStatusRepo(_context);
        public ISalesOrderItemRepo SalesOrderItemRepo => _salesorderitemRepo ??= new SalesOrderItemRepo(_context);
        public ISalesOrderRepo SalesOrderRepo => _salesorderRepo ??= new SalesOrderRepo(_context);
        public IProfPersonRepo ProfPersonRepo => _profpersonRepo ??= new ProfPersonRepo(_context);
        public IProductVariationRepo ProductVariationRepo => _productvariationRepo ??= new ProductVariationRepo(_context);
        public IProductTempImageRepo ProductTempImageRepo => _producttempimageRepo ??= new ProductTempImageRepo(_context);
        public IProductStatusRepo ProductStatusRepo => _productstatusRepo ??= new ProductStatusRepo(_context);
        public IProductSoldHistoryRepo ProductSoldHistoryRepo => _productsoldhistoryRepo ??= new ProductSoldHistoryRepo(_context);
        public IProductImageRepo ProductImageRepo => _productimageRepo ??= new ProductImageRepo(_context);
        public IProductColorRepo ProductColorRepo => _productcolorRepo ??= new ProductColorRepo(_context);
        public IGenStockManagementRestockOrderStatusRepo GenStockManagementRestockOrderStatusRepo => _genstockmanagementrestockorderstatusRepo ??= new GenStockManagementRestockOrderStatusRepo(_context);
        public IGenCrmCompanyTypeRepo GenCrmCompanyTypeRepo => _gencrmcompanytypeRepo ??= new GenCrmCompanyTypeRepo(_context);
        public IGenCountryRepo GenCountryRepo => _gencountryRepo ??= new GenCountryRepo(_context);
        public ICrmCompanyRepo CrmCompanyRepo => _crmcompanyRepo ??= new CrmCompanyRepo(_context);
        public ICrmClientProfileRepo CrmClientProfileRepo => _crmclientprofileRepo ??= new CrmClientProfileRepo(_context);
        public IAspNetUserTokenRepo AspNetUserTokenRepo => _aspnetusertokenRepo ??= new AspNetUserTokenRepo(_context);
        public IAspNetUserLoginRepo AspNetUserLoginRepo => _aspnetuserloginRepo ??= new AspNetUserLoginRepo(_context);
        public IAspNetUserClaimRepo AspNetUserClaimRepo => _aspnetuserclaimRepo ??= new AspNetUserClaimRepo(_context);
        public IAspNetUserRepo AspNetUserRepo => _aspnetuserRepo ??= new AspNetUserRepo(_context);
        public IAspNetRoleClaimRepo AspNetRoleClaimRepo => _aspnetroleclaimRepo ??= new AspNetRoleClaimRepo(_context);
        public IAspNetRoleRepo AspNetRoleRepo => _aspnetroleRepo ??= new AspNetRoleRepo(_context);
        public IApiDataLoggingRepo ApiDataLoggingRepo => _apidataloggingRepo ??= new ApiDataLoggingRepo(_context);
        public IAccResetPasswordDetailRepo AccResetPasswordDetailRepo => _accresetpassworddetailRepo ??= new AccResetPasswordDetailRepo(_context);

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
