using Microsoft.EntityFrameworkCore;
using SchoolAPI.Models;

namespace SchoolAPI.DataBase.Repositories
{
    public class AlunoRepository : BaseRepository<Aluno, int>, IAlunoRepository
    {
        public AlunoRepository(EscolaDBContext contexto) : base(contexto)
        {

        }

        public override Aluno Get(int id)
        {
            return _context.Alunos.Include(x => x.Boletins).Include(x => x.Turmas).FirstOrDefault(x => id == x.Id);
        }

        public bool EmailJaCadastrado(string email)
            => _context.Alunos.Any(x => x.Email == email);

    }
}
