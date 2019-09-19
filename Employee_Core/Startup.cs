using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Employee_Core.Models;
using Employee_Core.Repository;
using Newtonsoft.Json.Serialization;
using Employee_Core.Repository.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Autofac;

namespace Employee_Core
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public static IContainer container { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(Options =>
                {
                    Options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = "https://localhost:44360",
                        ValidAudience = "https://localhost:44360",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"))
                    };
                });
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<Employee_DatabaseContext>(item => item.UseSqlServer(Configuration.GetConnectionString("EmployeeDBConnection")));
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IRatingRepository, RatingRepository>();
            services.AddScoped<IStateRepository, StateRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();

            services.AddCors(option => option.AddPolicy("MyEmployeePolicy", builder =>
            {
                builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            }));

            services.AddMvc(options =>
            {
                options.Filters.Add(new ProducesAttribute("application/json"));
            });

            services.AddMvc().AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseCors("MyEmployeePolicy");
            app.UseMvc();
        }
    }
}
