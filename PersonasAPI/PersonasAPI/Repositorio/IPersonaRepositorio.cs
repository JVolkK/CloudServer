using PersonasAPI.Modelos;

namespace PersonasAPI.Repositorio
{
    public interface IPersonaRepositorio
    {
        Task<List<Personas>> GetPersonas();
        Task<List<Personas>> GetPersonasById(int id);
        Task<List<Personas>> CrearOActualizar(Personas persona);
        Task<bool> DeletePersonas(int id);
    }
}
