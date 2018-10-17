using Autofac;
using Autofac.Extensions.DependencyInjection;
using ClassroomManagement.Models;
using ClassroomManagementApi.Models;
using ClassroomManagementApi.Models.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace ClassroomManagementApi
{
    public class Startup
    {
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // we can add here services
           
            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //the 1st way
            //services.AddTransient<IClassroomManagementRepository, ClassroomManagementRepository>();

            //the 2nd way
            // Now register our services with Autofac container
            var builder = new ContainerBuilder();
            builder.RegisterType<ClassroomManagementRepository>().As<IClassroomManagementRepository>();
            builder.Populate(services);
            var container = builder.Build();
            //Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(container);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}