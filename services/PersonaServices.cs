using Backend.Controllers;

namespace Backend.services
{
    public class PersonaServices: IPersonaServices
    {
        public bool validate (PersonaDatos persona)
        {
            if (string.IsNullOrEmpty(persona.name) || persona.name.Length > 10)
            {
                return false;
            }
            return true;
        }
    }
}
