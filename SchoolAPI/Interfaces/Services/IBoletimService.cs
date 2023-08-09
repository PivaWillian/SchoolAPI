using SchoolAPI.Models;

namespace SchoolAPI.Interfaces.Services
{
    public interface IBoletimService
    {
        public Boletim ObterPorId(int id);
        public List<Boletim> ObterPorAluno(int alunoId);
        Boletim Cadastrar(Boletim boletim);
        Boletim Atualizar(Boletim boletim);
        void Excluir(int id);

    }
}
