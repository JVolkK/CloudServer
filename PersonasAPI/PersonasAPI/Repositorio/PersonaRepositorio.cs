using Microsoft.EntityFrameworkCore;
using PersonasAPI.Data;
using PersonasAPI.Modelos;

namespace PersonasAPI.Repositorio
{
    public class PersonaRepositorio : IPersonaRepositorio
    {
        private DataContext _context { get; set; }

        public Task<List<Personas>> CrearOActualizar(Personas persona)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeletePersonas(int id)
        {
            try
            {
                var persona = await _context.Personas.FindAsync(id);
                if (persona != null) 
                {
                    _context.Personas.Remove(persona);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;   
            }
            catch (Exception ex) 
            {
                throw;
            }
        }

        public async Task<List<Personas>> GetPersonas()
        {
            List<Personas> personas = await _context.Personas.ToListAsync();
            return personas;
        }

        public Task<List<Personas>> GetPersonasById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
