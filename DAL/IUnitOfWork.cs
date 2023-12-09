using DAL.Services;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUnitOfWork
    {
        //IProfileRepos ProfileRepos { get; }
        IUserRepos UserRepos { get; }
        INotificationRepo NotificationRepository { get; }
        IResetPasswordRepo ResetPasswordRepo { get; }
        IPhoneOtpRepo PhoneOtpRepo { get; }
        ICategoryRepo CategoryRepo { get; }
        ISubcategoryRepo SubcategoryRepo { get; }
        IProductRepo ProductRepo { get; }
        // repository goes here
       IStockManagementRestockOrderItemRepo StockManagementRestockOrderItemRepo { get; }
       IStockManagementRestockOrderRepo StockManagementRestockOrderRepo { get; }
       IStockManagementInventoryRepo StockManagementInventoryRepo { get; }
       ISalesOrderTimelineRepo SalesOrderTimelineRepo { get; }
       ISalesOrderStatusRepo SalesOrderStatusRepo { get; }
       ISalesOrderItemRepo SalesOrderItemRepo { get; }
       ISalesOrderRepo SalesOrderRepo { get; }
       IProfPersonRepo ProfPersonRepo { get; }
       IProductVariationRepo ProductVariationRepo { get; }
       IProductTempImageRepo ProductTempImageRepo { get; }
       IProductStatusRepo ProductStatusRepo { get; }
       IProductSoldHistoryRepo ProductSoldHistoryRepo { get; }
       IProductImageRepo ProductImageRepo { get; }
       IProductColorRepo ProductColorRepo { get; }
       IGenStockManagementRestockOrderStatusRepo GenStockManagementRestockOrderStatusRepo { get; }
       IGenCrmCompanyTypeRepo GenCrmCompanyTypeRepo { get; }
       IGenCountryRepo GenCountryRepo { get; }
       ICrmCompanyRepo CrmCompanyRepo { get; }
       ICrmClientProfileRepo CrmClientProfileRepo { get; }
       IAspNetUserTokenRepo AspNetUserTokenRepo { get; }
       IAspNetUserLoginRepo AspNetUserLoginRepo { get; }
       IAspNetUserClaimRepo AspNetUserClaimRepo { get; }
       IAspNetUserRepo AspNetUserRepo { get; }
       IAspNetRoleClaimRepo AspNetRoleClaimRepo { get; }
       IAspNetRoleRepo AspNetRoleRepo { get; }
       IApiDataLoggingRepo ApiDataLoggingRepo { get; }
       IAccResetPasswordDetailRepo AccResetPasswordDetailRepo { get; }
        void Save();
        Task SaveAsync();
    }
}
