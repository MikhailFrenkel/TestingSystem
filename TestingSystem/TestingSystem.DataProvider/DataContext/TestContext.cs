using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TestingSystem.Model;

namespace TestingSystem.DataProvider.DataContext
{
    class TestContext : DbContext
    {
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
    }
}
