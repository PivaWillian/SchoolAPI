using SchoolAPI.Models;

namespace SchoolAPI.Interfaces.Repositories
{
    public interface IMateriaRepository: IBaseRepository<Materia, int>
    {
        Materia Get(int id);
        IEnumerable<Materia> GetAll();
        void Delete(Materia materia);
        Materia Post(Materia materia);
        Materia Update(Materia materia);
    }
}