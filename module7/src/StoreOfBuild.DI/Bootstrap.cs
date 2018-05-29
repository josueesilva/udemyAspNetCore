using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using StoreOfBuild.Data;
using StoreOfBuild.Data.Contexts;
using StoreOfBuild.Data.Repositories;
using StoreOfBuild.Domain;
using StoreOfBuild.Domain.Products;
using StoreOfBuild.Domain.Sales;
using StoreOfBuild.Data.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace StoreOfBuild.DI
{
    public class Bootstrap
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            services.AddIdentity<ApplicationUser, IdentityRole>(config => {
                    config.Password.RequireDigit = true;
                    config.Password.RequiredLength = 3;
                    config.Password.RequireLowercase = false;
                    config.Password.RequireNonAlphanumeric = false;
                    config.Password.RequireUppercase = false;            
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
                
            services.ConfigureApplicationCookie(options =>
            {
                    options.AccessDeniedPath = "/Account/AccessDenied";
                    options.Cookie.Name = "YourAppCookieName";
                    options.Cookie.HttpOnly = true; 
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(60); 
                    options.LoginPath = "/Account/Login";
                    // ReturnUrlParameter requires `using Microsoft.AspNetCore.Authentication.Cookies;`
                    options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                    options.SlidingExpiration = true;
                });
            services.AddScoped(typeof(IRepository<Product>), typeof(ProductRepository));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(CategoryStorer));
            services.AddScoped(typeof(ProductStorer));
            services.AddScoped(typeof(SaleFactory));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
        }
    }
}
