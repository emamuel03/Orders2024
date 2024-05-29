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
                _context.Countries.Add(new Shared.Entities.Country { Name = "Argentina" });
                _context.Countries.Add(new Shared.Entities.Country { Name = "Brasil" });
                _context.Countries.Add(new Shared.Entities.Country { Name = "Uruguay" });
                _context.Countries.Add(new Shared.Entities.Country { Name = "Paraguay" });
                _context.Countries.Add(new Shared.Entities.Country { Name = "Chile" });
                await _context.SaveChangesAsync();
            }
        }
    }
}