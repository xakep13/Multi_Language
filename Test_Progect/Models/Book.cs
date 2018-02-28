using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Progect.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
                ErrorMessageResourceName = "NameRequired")]
        [Display(Name = "Name", ResourceType = typeof(Resources.Resource))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
                ErrorMessageResourceName = "AuthorRequired")]
        [Display(Name = "Author", ResourceType = typeof(Resources.Resource))]
        public string Author { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
                ErrorMessageResourceName = "YearRequired")]
        [Display(Name = "Year", ResourceType = typeof(Resources.Resource))]
        public int Year { get; set; }
    }
}
