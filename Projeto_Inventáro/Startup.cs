using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Projeto_Inventáro.Models.Context;
using Projeto_Inventáro.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto_Inventáro.Services;
using Projeto_Inventáro.Repository;
using Projeto_Inventáro.Repository.Generic;
using Projeto_Inventáro.Repository.Implementations;
using Microsoft.Net.Http.Headers;

namespace Projeto_Inventáro
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


            services.AddControllers();

            //DATABSE
            var connection = Configuration["MySQLConnection:MySQLConnectionString"];
            services.AddDbContext<MySQLContext>(options => options.UseMySql(connection, ServerVersion.AutoDetect(connection)));



            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;

                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));

                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));




            })
                .AddXmlSerializerFormatters();




            //versionamento da api
            services.AddApiVersioning();
            




            //Dependncy Injection
            services.AddScoped<IComputadorService, ComputadorServiceImplementation>();
            services.AddScoped<IComputadorRepository, ComputadorRepositoryImplementation>();


            services.AddScoped<IUsuarioService, UsuarioServiceImplementation>();
            services.AddScoped<IUsuarioRepository, UsuarioRepositoryImplementation>();


            services.AddScoped<ISetorService,  SetorServiceImplementation>();
            services.AddScoped<ISetorRepository, SetorRepositoryImplementation > ();


            services.AddScoped<IModeloService, ModeloServiceImplementation>();
            services.AddScoped<IModeloRepositorycs, ModeloRepositoryImplementation>();

            services.AddScoped<IEquipamentoService, EquipamentoServiceImplementation>();
            services.AddScoped<IEquipamentoRepository, EquipamentoRepositoryImplementationcs>();




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
