using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_Progect.Models;

namespace Test_Progect
{
    public class SampleData
    {
        public static void Initialize(UserContext context)
        {
            if (!context.Books.Any())
            {
                context.Books.AddRange(
                    new Book
                    {
                        Name = "Гаррі Поттер",
                        Author = "Роунг",
                        Year = 1991
                    },
                    new Book
                    {
                        Name = "Samsung Galaxy Edge",
                        Author = "Samsung",
                        Year = 2000
                    },
                    new Book
                    {
                        Name = "Lumia 950",
                        Author = "Microsoft",
                        Year = 2015
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
