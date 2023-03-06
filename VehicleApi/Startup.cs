using HealthEquity.Controllers;
using HealthEquity.Models;
using HealthEquity.Repositories;
using HealthEquity.Services;
using HealthEquity.Uow;

namespace HealthEquity
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            var cars = new List<Car>()
    {
        new Car()
        {
            Id = 1,
            Make = "Audi",
            Model = "R8",
            Year = 2018,
            Doors = 2,
            Color = "Red",
            Price = 79995.00
        },
        new Car()
        {
            Id = 2,
            Make = "Tesla",
            Model = "3",
            Year = 2018,
            Doors = 4,
            Color = "Black",
            Price = 54995.00
        },
        new Car()
        {
            Id = 3,
            Make = "Porsche",
            Model = "911 991",
            Year = 2020,
            Doors = 2,
            Color = "White",
            Price = 155000.00
        },
          new Car()
        {
            Id = 4,
            Make = "Mercedes-Benz",
            Model = "GLE 63S",
            Year = 2021,
            Doors = 5,
            Color = "Blue",
            Price = 83995.00
        },
            new Car()
        {
            Id = 5,
            Make = "BMW",
            Model = "X6 M",
            Year = 2020,
            Doors = 5,
            Color = "Silver",
            Price = 62995.00
        }
    };

            services.AddControllers();
            services.AddTransient<CarController>();
            services.AddSingleton<ICarRepository, CarRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICarService, CarService>();
            services.AddSingleton<List<Car>>(cars);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}