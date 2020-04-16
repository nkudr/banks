using System;
using Microsoft.EntityFrameworkCore;

namespace Banks
{
    public class ApplicationContext: DbContext
    {
		public DbSet<Models.Bank> Banks { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
			optionsBuilder.UseMySQL("server=localhost;UserId=root;Password=;database=banks;");
		}
	}
}
