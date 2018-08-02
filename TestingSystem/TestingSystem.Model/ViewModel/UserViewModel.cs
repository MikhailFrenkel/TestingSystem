using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using TestingSystem.Model.Identity;

namespace TestingSystem.Model.ViewModel
{
    public class UserViewModel
    {
        public string UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public IList<Result> Results { get; set; }

        public UserViewModel()
        {
        }

        public UserViewModel(ApplicationUser user)
        {
            Results = new List<Result>();

            UserName = user.UserName;

            Email = user?.Email;

            if (user.Results != null)
                Results = user.Results.OrderByDescending(x => x.DateOfPassing).ToList();
        }
    }
}
