using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TestingSystem.Model.Identity
{
    public class Role : IdentityRole<Guid, UserRole>
    {
    }
}
