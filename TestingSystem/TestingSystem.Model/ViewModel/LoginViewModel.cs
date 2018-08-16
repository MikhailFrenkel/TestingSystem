using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.Model.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Incorrect login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Incorrect pasword")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string UrlReferrer { get; set; }
    }
}
