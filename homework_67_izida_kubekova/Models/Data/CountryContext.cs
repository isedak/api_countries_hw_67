using Microsoft.EntityFrameworkCore;

namespace homework_67_izida_kubekova.Models.Data
{
    public sealed class CountryContext: DbContext
    {
        public DbSet<Country> Countries { get; set; }

        public CountryContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                new Country
                    { Id = 1, Name = "Россия", Capital = "Москва", Population = 145478097},
                new Country
                    { Id = 2, Name = "Белорусь", Capital = "Минск", Population = 9255524},
                new Country
                    { Id = 3, Name = "Южная Осетия", Capital = "Цхинвал", Population = 53556},
                new Country
                    { Id = 4, Name = "Луганская Народная Республика", Capital = "Луганск", Population = 1399453},
                new Country
                    { Id = 5, Name = "Донецкая Народная Республика", Capital = "Донецк", Population = 2202440},
                new Country
                    { Id = 6, Name = "Армения", Capital = "Ереван", Population = 2963243},
                new Country
                    { Id = 7, Name = "Киргизия", Capital = "Бишкек", Population = 6580166},
                new Country
                    { Id = 8, Name = "Таджикистан", Capital = "Душанбе", Population = 9935552},
                new Country
                    { Id = 9, Name = "Узбекистан", Capital = "Ташкент", Population = 35271276},
                new Country
                    { Id = 10, Name = "Казахстан", Capital = "Нурсултан", Population = 19352685}
            
            );
        }
    }
}