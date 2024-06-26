﻿using Orders.Backend.UnitsOfWork.Interfaces;
using Orders.Shared.Entities;
using Orders.Shared.Enums;

namespace Orders.Backend.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUsersUnitOfWork _usersUnitOfWork;

        public SeedDb(DataContext context, IUsersUnitOfWork usersUnitOfWork)
        {
            _context = context;
            _usersUnitOfWork = usersUnitOfWork;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCountriesAsync();
            await CheckCategoriesAsync();
            await CheckRolesAsync();
            await CheckUserAsync("1010", "Emmanuel", "Gomez", "egomez@tucumail.com", "322 311 341", "Av. Siempres viva 123", UserType.Admin);
        }

        private async Task CheckRolesAsync()
        {
            await _usersUnitOfWork.CheckRoleAsync(UserType.Admin.ToString());
            await _usersUnitOfWork.CheckRoleAsync(UserType.User.ToString());
        }

        private async Task<User> CheckUserAsync(string document, string firstName, string lastName, string email, string phone, string address, UserType userType)
        {
            var user = await _usersUnitOfWork.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                    City = _context.Cities.FirstOrDefault(),
                    UserType = userType
                };
                await _usersUnitOfWork.AddUserAsync(user, "123456");
                await _usersUnitOfWork.AddUserToRoleAsync(user, userType.ToString());
            }

            return user;
        }

        private async Task CheckCategoriesAsync()
        {
            if (!_context.Categories.Any())
            {
                _context.Categories.Add(new Shared.Entities.Category { Name = "Tecnologia" });
                _context.Categories.Add(new Shared.Entities.Category { Name = "Mascotas" });
                _context.Categories.Add(new Shared.Entities.Category { Name = "Hogar" });
                _context.Categories.Add(new Shared.Entities.Category { Name = "Cosmeticos" });
                _context.Categories.Add(new Shared.Entities.Category { Name = "Jardinería" });
                _context.Categories.Add(new Shared.Entities.Category { Name = "Videojuegos" });
                _context.Categories.Add(new Shared.Entities.Category { Name = "Calzados" });
                _context.Categories.Add(new Shared.Entities.Category { Name = "Vestimenta" });
                _context.Categories.Add(new Shared.Entities.Category { Name = "PC" });
                _context.Categories.Add(new Shared.Entities.Category { Name = "Electrodomésticos" });
                _context.Categories.Add(new Shared.Entities.Category { Name = "TVs" });
                _context.Categories.Add(new Shared.Entities.Category { Name = "Muebles de interior" });
                _context.Categories.Add(new Shared.Entities.Category { Name = "Bicicletas" });
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