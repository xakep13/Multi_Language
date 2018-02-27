using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Progect.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Не вказаний логін")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не вказаний пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
