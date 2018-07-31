using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using TestingSystem.DataProvider.DataContext;
using TestingSystem.Model.Identity;

namespace TestingSystem.DataProvider.Manager
{
    public class ApplicationUserStore : UserStore<ApplicationUser>
    {
        public ApplicationUserStore(ApplicationDbContext db) : base(db)
        {
        }
    }
}
