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
using Projeto_Inventáro.Hypermedia.Filters;
using Projeto_Inventáro.Hypermedia.Enricher;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Rewrite;

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
            services.AddCors(options => options.AddDefaultPolicy(buider =>

            {
                buider.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();


            }));

            services.AddControllers();

            //DATABSE
            var connection = Configuration["MySQLConnection:MySQLConnectionString"];
            services.AddDbContext<MySQLContext>(options => options.UseMySql(connection, ServerVersion.AutoDetect(connection)));


                     //conversão de xml e json
            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;

                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));

                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));




            })
                .AddXmlSerializerFormatters();


            // Hateos
            var filterOptions = new HypeMediaFilterOptions();

            filterOptions.ResponseEnrichers.Add(new ComputadorEnricher());

            services.AddSingleton(filterOptions);


            //versionamento da api
            services.AddApiVersioning();


            services.AddSwaggerGen(c => {


                c.SwaggerDoc("v1",

                   new OpenApiInfo
                   {
                       Title = "APi do inventário de computadores do Sesc",
                       Version = "v1",
                       Description = "Api para o controle de computadores do sesc",
                       Contact = new OpenApiContact
                       {
                           Name = "Bruno Gonaçalves ",
                          Url = new Uri("https://github.com/SrMorpheus")
                       }

                   });






            });
            




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

            app.UseCors();

            app.UseSwagger();

            app.UseSwaggerUI(c => {

                c.SwaggerEndpoint("/swagger/v1/swagger.json", "APi do inventário de computadores do Sesc - v1");
            
            
            });
            var option = new RewriteOptions();

            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute("DefaultApi", "{controller=values}/{id}");
                
                //endpoints.MapControllerRoute("DefaultApi", "{controller=values}/{id}");
            });
        }
    }
}
