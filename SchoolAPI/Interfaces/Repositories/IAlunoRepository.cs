using SchoolAPI.Models;

namespace SchoolAPI.Interfaces.Repositories
{
    public interface IAlunoRepository : IBaseRepository<Aluno, int>
    {
        public bool EmailJaCadastrado(string email);
    }
}
