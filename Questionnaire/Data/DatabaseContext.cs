using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Questionnaire.Model;
using System.Configuration;
using System.IO;

namespace Questionnaire.Data
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext() { }
		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

		public DbSet<Question> Questions { get; set; }
		public DbSet<Answer> Answers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DatabaseConnect");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
