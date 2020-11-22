using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var uow = scope.ServiceProvider.GetService<IUnitOfWork>();
                await SeedData(uow);
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static async Task SeedData(IUnitOfWork unitOfWork)
        {
            await unitOfWork.GemeenteRepository.AddRangeAsync(new List<Gemeente>
            {
                new Gemeente
                {
                    Name = "A",
                    Provincie = new Provincie
                    {
                        Name = "Pr",
                        Hoofdstad = "ho",
                        OppervlakteKm = 42
                    },
                    AantalInwoners = 420
                }
            });

            await unitOfWork.SaveChangesAsync();
        }
    }
}
