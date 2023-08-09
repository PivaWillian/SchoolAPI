using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolAPI.Interfaces.Repositories;
using SchoolAPI.Models;

namespace SchoolAPI.DataBase.Repositories
{
    public class MateriaRepository: BaseRepository<Materia, int>, IMateriaRepository
    {

        public MateriaRepository(EscolaDBContext contexto): base(contexto) { }

        public Materia Get(int id) 
        {
            return _context.Set<Materia>().FirstOrDefault(x => x.Id == id);
        }

        public Materia Get([FromQuery]string nome)
        {
            return _context.Set<Materia>().FirstOrDefault(x => x.Name == nome);
        }

        public IEnumerable<Materia> GetAll() 
        {
            return _context.Set<Materia>().ToList();
        }
        void Delete(Materia materia) { }
        Materia Post(Materia materia) { }
        Materia Update(Materia materia) { }
    }
}
