using InstantAPIs;
using Microsoft.EntityFrameworkCore;
using Project.Data.Context;
using Project.Data.DapperConnection;
using Project.Data.IRepository;
using Project.Data.Repository;
using Project.Service.IService;
using Project.Service.Service;
using Microsoft.Data.Sqlite;
using Project.Data.UoW;
using Project.Common.Models;

namespace WEB.StartupExtentions
{
    public static class StartupConfigurations
    {
        public static IServiceCollection ConfiguringRepositories(this IServiceCollection services)
        {
            services.AddScoped<IDapperConnection, DapperConnection>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

        public static IServiceCollection ConfiguringServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            return services;
        }

        public static IServiceCollection ConfiguringGlobalServices(this IServiceCollection services, IConfiguration configuration)
        {

            //REGISTER YOUR DBCONTEXT
			
			//IF USE MSSQL
            //services.AddDbContext<testcontext>(option =>
            //{
            //    option.UseSqlServer(configuration.GetValue<string>("SqlConnectionConfig:SqlConnection").ToString());
            //    option.UseSqlServer(configuration.GetValue<string>("SqlConnectionConfig:SqlConnection").ToString(), b => b.MigrationsAssembly("Project.Api"));
            //});

			//IF USE SQLLITE (SQLLITE DATABASE)
            services.AddDbContext<testcontext>(option =>
            {
                option.UseSqlite(configuration.GetConnectionString("sqlliteconnection").ToString(), b => b.MigrationsAssembly("Project.Api"));
            });


            // IT USED TO CREATE INSTANCE API
            services.AddInstantAPIs();

            services.AddSingleton(s => configuration.GetSection("SqlConnectionConfig").Get<SqlConnectionConfig>());
            return services;
        }

        //public static IServiceCollection setJwtSettings(this IServiceCollection services, IConfiguration configuration)
        //{
        //    services.Configure<TokenOptions>(configuration.GetSection("TokenOptions"));
        //    var tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();

        //    var signingConfigurations = new SigningConfigurations(tokenOptions.Secret);
        //    services.AddSingleton(signingConfigurations);

        //    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        //        .AddJwtBearer(options =>
        //        {
        //            options.TokenValidationParameters = new TokenValidationParameters
        //            {
        //                ValidateIssuer = true,
        //                ValidateAudience = true,
        //                ValidateLifetime = true,
        //                ValidateIssuerSigningKey = true,
        //                ValidIssuer = tokenOptions.Issuer,
        //                ValidAudience = tokenOptions.Audience,
        //                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.Secret))
        //            };
        //        });

        //    return services;
        //}

        public static void AddCorsCustom(this IServiceCollection services)
        {
            services.AddCors(o =>
            {
                //o.AddPolicy("AllowCommonApiOrigin", builder => builder.WithOrigins("http://localhost:5002").AllowAnyMethod().AllowAnyHeader());
                o.AddPolicy("MyPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
        }
    }
}
