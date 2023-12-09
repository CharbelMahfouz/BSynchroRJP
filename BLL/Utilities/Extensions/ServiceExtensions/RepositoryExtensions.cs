
using BLL.IServices;
using BLL.Service;
using BLL.Utilities.ActionFilters;
using BLL.Utilities.Mailkit;
using DAL;
using DAL.Models;
using DAL.Repos;
using DAL.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Utilities.Extensions.ServiceExtensions
{
    public static class RepositoryExtensions
    {
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            // inject repo here
            services.AddScoped<IGenericRepos<Transaction>, GenericRepos<Transaction>>();
            services.AddScoped<IGenericRepos<Customer>, GenericRepos<Customer>>();
            services.AddScoped<IGenericRepos<CurrentAccount>, GenericRepos<CurrentAccount>>();
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<ValidationFilterAttribute>();
            services.AddScoped<BaseBL>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAccountsBL, AccountsBL>();
            services.AddScoped<ITransactionsBL, TransactionsBL>();
            services.AddScoped<ICustomersBL, CustomersBL>();
            services.AddScoped<IDbInitializer, DbInitializer>();

        }
    }
}
