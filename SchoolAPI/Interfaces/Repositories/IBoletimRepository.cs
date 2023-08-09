using SchoolAPI.Models;

namespace SchoolAPI.Interfaces.Repositories
{
    public interface IBoletimRepository : IBaseRepository<Boletim, int>
    {
        Boletim Get(int alunoId);
        List<Boletim> GetAll(int alunoId);
        Boletim Post(Boletim boletim);
        void Delete(Boletim boletim);
        Boletim Update(Boletim boletim);
    }
}
