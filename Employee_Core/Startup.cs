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

namespace Employee_Core
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<Employee_DatabaseContext>(item => item.UseSqlServer(Configuration.GetConnectionString("EmployeeDBConnection")));
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ICityRepository,CityRepository>();
            services.AddScoped<IDepartmentRepository,DepartmentRepository>();
            services.AddScoped<IRatingRepository,RatingRepository>();
            services.AddScoped<IStateRepository,StateRepository>();
            services.AddScoped<ISkillRepository,SkillRepository>();

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

            app.UseHttpsRedirection();
            app.UseCors("MyEmployeePolicy");
            app.UseMvc();
        }

        
    }
}
