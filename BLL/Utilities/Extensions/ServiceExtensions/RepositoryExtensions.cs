
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
            
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<BaseBL>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
