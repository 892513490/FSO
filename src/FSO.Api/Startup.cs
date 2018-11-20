using System;
using System.IO;
using System.Text;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FSO.Models;
using FSO.Repository;
using FSO.Repository.Implements;
using FSO.Service;
using FSO.Service.Implements;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;

namespace FSO.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IContainer ApplicationContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<MySqlContext>(options => options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));

            services.AddSwaggerGen(option => {
                option.SwaggerDoc("api", new Info()
                {
                    Version = "v1",
                    Title = "接口文档",
                    Description = "api",
                    TermsOfService = "None",
                    Contact = new Contact() { Name = "", Email = "", Url = "" }
                });

                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "FSO.Api.xml");
                option.IncludeXmlComments(xmlPath);
            });

            services.AddMvc().AddJsonOptions(options=> {
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Create the container builder.
            var builder = new ContainerBuilder();
            builder.RegisterType<UrlRepository<UrlInfo>>().As<IUrlRepository<UrlInfo>>();
            builder.RegisterType<UrlInfoService>().As<IUrlInfoService>();

            //var assembly = System.Reflection.Assembly.GetEntryAssembly();
            //builder.RegisterAssemblyTypes(assembly);

            builder.Populate(services);
            this.ApplicationContainer = builder.Build();

            // Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(this.ApplicationContainer);
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

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);//这是为了防止中文乱码

            app.UseSwagger();
            app.UseSwaggerUI(option => {
                option.SwaggerEndpoint("/swagger/api/swagger.json", "api v1");
            });
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
