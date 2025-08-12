using Microsoft.EntityFrameworkCore;
using project_school_API.Data;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace project_school_API;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // Configuração de serviços
    public void ConfigureServices(IServiceCollection services)
    {

        services.AddDbContext<DataContext>(option => 
            option.UseSqlite(Configuration.GetConnectionString("DefaultConnection"))
            //.EnableSensitiveDataLogging()
            );
        services.AddScoped<IRepository, Repository>();

        //TODO mudar para usar mapping com dtos das entidades 
        services.AddControllers()
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

        //referencia de id torna o json mais complexo de se ler
        //apesar de ser uma solução melhor que o ignore para looping


         /*
        services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            });
        */



        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    // Configuração do pipeline HTTP
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
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