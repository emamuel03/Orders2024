using Orders.Shared.Entities;

namespace Orders.Backend.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCountriesAsync();
            await CheckCategoriesAsync();
        }

        private async Task CheckCategoriesAsync()
        {
            if (!_context.Categories.Any())
            {
                _context.Categories.Add(new Shared.Entities.Category { Name = "Tecnologia" });
                _context.Categories.Add(new Shared.Entities.Category { Name = "Mascotas" });
                _context.Categories.Add(new Shared.Entities.Category { Name = "Hogar" });
                _context.Categories.Add(new Shared.Entities.Category { Name = "Cosmeticos" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckCountriesAsync()
        {
            if (!_context.Countries.Any())
            {
                _context.Countries.Add(new Shared.Entities.Country 
                { 
                    Name = "Argentina",
                    States = new List<State>()
                    {
                        new State()
                        {
                            Name = "Tucuman",
                            Cities = new List<City>()
                            {
                                new City() { Name = "San Miguel de Tucuman" },
                                new City() { Name = "Lastenia" },
                                new City() { Name = "Banda del Rio Sali" },
                                new City() { Name = "Tafi Viejo" },
                                new City() { Name = "Yerba Buena" }
                            }
                        },
                        new State()
                        {
                            Name = "Salta",
                            Cities = new List<City>()
                            {
                                new City() { Name = "Salta Capital" },
                                new City() { Name = "Guemes" },
                                new City() { Name = "Tartagal" },
                                new City() { Name = "Rosario de La Frontera" },
                            }
                        },
                        new State()
                        {
                            Name = "Jujuy",
                            Cities = new List<City>()
                            {
                                new City() { Name = "San Salvador de Jujuy" },
                                new City() { Name = "Ledesma" },
                                new City() { Name = "Humahuaca" },
                                new City() { Name = "Pumamarca" },
                            }
                        },
                    },
                });
                _context.Countries.Add(new Shared.Entities.Country
                {
                    Name = "Uruguay",
                    States = new List<State>()
                    {
                        new State()
                        {
                            Name = "Montevideo",
                            Cities = new List<City>()
                            {
                                new City() { Name = "Villa del Cerro" },
                                new City() { Name = "Penarol" },
                                new City() { Name = "Palermo" },
                                new City() { Name = "Bella Vista" },
                                new City() { Name = "Colon" }
                            }
                        },
                        new State()
                        {
                            Name = "Paysandu",
                            Cities = new List<City>()
                            {
                                new City() { Name = "Paysandu Capital" },
                                new City() { Name = "Guichon" },
                                new City() { Name = "Porvenir" },
                                new City() { Name = "Quebracho" },
                            }
                        },
                        new State()
                        {
                            Name = "Canelones",
                            Cities = new List<City>()
                            {
                                new City() { Name = "18 de Mayo" },
                                new City() { Name = "La Paz" },
                                new City() { Name = "San Ramon" },
                                new City() { Name = "Tala" },
                            }
                        },
                    },
                });
                _context.Countries.Add(new Shared.Entities.Country
                {
                    Name = "Brasil",
                    States = new List<State>()
                    {
                        new State()
                        {
                            Name = "Rio de Janeiro",
                            Cities = new List<City>()
                            {
                                new City() { Name = "Rio de Janeiro" },
                                new City() { Name = "Sao Goncalo" },
                                new City() { Name = "Duque de Caixas" },
                                new City() { Name = "Nova Iguacu" },
                                new City() { Name = "Belford Roxo" }
                            }
                        },
                        new State()
                        {
                            Name = "Sao Paulo",
                            Cities = new List<City>()
                            {
                                new City() { Name = "Campinas" },
                                new City() { Name = "sao Carlos" },
                                new City() { Name = "Santos" },
                                new City() { Name = "Sao jose dos Campos" },
                            }
                        },
                    },
                });
                await _context.SaveChangesAsync();
            }
        }
    }
}