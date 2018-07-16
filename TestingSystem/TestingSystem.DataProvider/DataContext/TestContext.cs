using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TestingSystem.Model;

namespace TestingSystem.DataProvider.DataContext
{
    public class TestContext : DbContext
    {
        /*public TestContext() : base("TestingSystem.DataProvider.DataContext.TestContext")
        {
        }*/

        public DbSet<Theme> Themes { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Theme>()
                .HasMany(x => x.Tests)
                .WithOptional(x => x.Theme);
        }*/
    }
}
