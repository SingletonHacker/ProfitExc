using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

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
                // await SeedData(uow);

                var seeder = new DataSeeder();
                seeder.SeedData(uow);
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
                        OppervlakteKm2 = 45
                    },
                    AantalInwoners = 4120
                },
                new Gemeente
                {
                    Name = "B",
                    Provincie = new Provincie
                    {
                        Name = "Pr2",
                        Hoofdstad = "ho2",
                        OppervlakteKm2 = 45
                    },
                    AantalInwoners = 4200
                },
                new Gemeente
                {
                    Name = "C",
                    Provincie = new Provincie
                    {
                        Name = "Pr3",
                        Hoofdstad = "ho3",
                        OppervlakteKm2 = 45
                    },
                    AantalInwoners = 4120110
                }
            });

            await unitOfWork.SaveChangesAsync();
        }

        private class DataSeeder
        {
            public async void SeedData(IUnitOfWork unitOfWork)
            {
                var gemeentes = ReadGemeentes();
                var provincies = ReadProvincies();

                var realGemeetnes = new List<Core.Entities.Gemeente>();

                foreach (var gemeente in gemeentes)
                {
                    var provincie = provincies.Single(p => p.Name == gemeente.provincie);

                    realGemeetnes.Add(new Gemeente
                    {
                        Name = gemeente.gemeente,
                        AantalInwoners = gemeente.inwoners,
                        Provincie = provincie
                    });
                }

                await unitOfWork.GemeenteRepository.AddRangeAsync(realGemeetnes);
                await unitOfWork.SaveChangesAsync();
            }

            private List<GemeenteObj> ReadGemeentes()
            {
                string json = File.ReadAllText(@"C:\git\Personal\ProfitExc\resources\gemeenten.json");
                var gemeenteList = JsonConvert.DeserializeObject<List<GemeenteObj>>(json);

                return gemeenteList;
            }

            private List<Core.Entities.Provincie> ReadProvincies()
            {
                var provincies = new List<Core.Entities.Provincie>();

                using (var reader = new StreamReader(@"C:\git\Personal\ProfitExc\resources\provincies.csv"))
                {
                    var header = reader.ReadLine();

                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var splittedLine = line.Split(",");

                        provincies.Add(new Provincie
                        {
                            Name = splittedLine[0],
                            Hoofdstad = splittedLine[1],
                            OppervlakteKm2 = int.Parse(splittedLine[2])
                        });

                        line = reader.ReadLine();
                    }
                }

                return provincies;
            }

            public class GemeenteObj
            {
                public string gemeente { get; set; }

                public string provincie { get; set; }

                public int inwoners { get; set; }
            }
        }
    }
}
