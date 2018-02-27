using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Progect.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не вказаний логін")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не вказаний пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введено не правильно")]
        public string ConfirmPassword { get; set; }
    }
}
