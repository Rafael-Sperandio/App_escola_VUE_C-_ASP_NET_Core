using Microsoft.EntityFrameworkCore;
using project_school_API.Data;

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
        services.AddControllers();
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