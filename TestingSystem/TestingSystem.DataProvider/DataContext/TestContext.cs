using System.Data.Entity;
using TestingSystem.Model;

namespace TestingSystem.DataProvider.DataContext
{
    public class TestContext : DbContext
    {
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
    }
}
