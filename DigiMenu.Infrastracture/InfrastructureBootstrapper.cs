using DigiMenu.Domain.CategoryAgg;
using DigiMenu.Domain.ProductAgg.Repositories;
using DigiMenu.Infrastracture.Persistent.EF;
using DigiMenu.Infrastracture.Persistent.EF.ProductAgg;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigiMenu.Infrastracture.Persistent.EF.CategoryAgg;
using DigiMenu.Domain.PageSettingAgg;
using DigiMenu.Infrastracture.Persistent.EF.PageSettingAgg;
using DigiMenu.Domain.RoleAgg.Repositories;
using DigiMenu.Infrastracture.Persistent.EF.RoleAgg;
using DigiMenu.Domain.UserAgg.Repositories;
using DigiMenu.Infrastracture.Persistent.EF.UserAgg;
using DigiMenu.Infrastracture.Persistent.Dapper;

namespace DigiMenu.Infrastracture
{
    public class InfrastructureBootstrapper
    {
        public InfrastructureBootstrapper(IServiceCollection services, string connectionString) 
        {
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IPageSettingRepository, PageSettingRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient(_ => new DapperContext(connectionString));
            services.AddDbContext<DigiMenuContext>(optionsAction =>
            {
                optionsAction.UseSqlServer(connectionString);
            });

        }
    }
}
