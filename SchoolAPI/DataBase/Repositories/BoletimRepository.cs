using Microsoft.EntityFrameworkCore;
using SchoolAPI.Models;
using SchoolAPI.Interfaces.Repositories;

namespace SchoolAPI.DataBase.Repositories
{
    public class BoletimRepository: BaseRepository<Boletim, int>, IBoletimRepository
    {
        public BoletimRepository(EscolaDBContext contexto) : base(contexto)
        {
        }

        public override List<Boletim> GetAll(int alunoId)
        {
            return _context.Set<Boletim>().Where(x => x.AlunoId == alunoId).ToList();
        }

        public override Boletim Get(int alunoId)
        {
            return _context.Set<Boletim>().Find(alunoId);
        }
    }
}
