using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;

namespace Backend.Controllers
{
    public class Repository
    {
        public static List<PersonaDatos> persona = new List<PersonaDatos>
        {
            new PersonaDatos()
            {
                id = 1,
                birthDate = new DateTime(1994, 08, 03),
                name = "Josue Aaron Castillo Valdiviezo",
                email = "example1@mail.com"
            },
            new PersonaDatos()
            {
                id = 2,
                birthDate = new DateTime(1994, 08, 03),
                name = "Josue Aaron",
                email = "example2@mail.com"
            },
            new PersonaDatos()
            {
                id = 3,
                birthDate = new DateTime(1994, 08, 03),
                name = "Josue",
                email = "example3@mail.com"
            }
        };
    }

    public class PersonaDatos
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime birthDate { get; set; }
        public string email { get; set; }

        // Propiedad calculada para obtener la edad
        public int age
        {
            get
            {
                var today = DateTime.Today;
                int age = today.Year - birthDate.Year;
                if (birthDate > today.AddYears(-age)) age--;
                return age;
            }
        }
    }
}


