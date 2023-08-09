using SchoolAPI.Models;

namespace SchoolAPI.Interfaces.Services
{
    public interface IAlunoService
    {
        public Aluno Criar(Aluno aluno);
        public Aluno ObterPorId(int id);
        public Aluno Atualizar(Aluno aluno);
        public List<Aluno> ObterAlunos();
        public void DeletarAluno(int id);
    }
}
