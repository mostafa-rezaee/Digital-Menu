using DigiMenu.Presentation.Facade.Categories;
using DigiMenu.Presentation.Facade.PageSettings;
using DigiMenu.Presentation.Facade.Products;
using DigiMenu.Presentation.Facade.Roles;
using DigiMenu.Presentation.Facade.Users;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Presentation.Facade
{
    public static class FacadeBootstrapper
    {
        public static void InitialaizeFacadeDependency(this IServiceCollection services)
        {
            services.AddScoped<ICategoryFacade, CategoryFacade>();
            services.AddScoped<IPageSettingFacade, PageSettingFacade>();
            services.AddScoped<IProductFacade, ProductFacade>();
            services.AddScoped<IRoleFacade, RoleFacade>();
            services.AddScoped<IUserFacade, UserFacade>();
           
        }
    }
}
