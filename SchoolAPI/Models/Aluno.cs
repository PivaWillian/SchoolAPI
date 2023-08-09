using System.Security.Cryptography.X509Certificates;
using SchoolAPI.DTO;

namespace SchoolAPI.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public int Idade { get; set; }
        public string Genero { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public virtual List<Boletim> Boletins { get; set; }
        public virtual List<Turma> Turmas { get; set; }

        public Aluno()
        {

        }

        public Aluno(AlunoDTO aluno)
        {
            Id = aluno.Id;
            Nome = aluno.Nome;
            SobreNome = aluno.SobreNome;
            Idade = aluno.Idade;
            Genero = aluno.Genero;
            Telefone = aluno.Telefone;
            Email = aluno.Email;

            if(DateTime.TryParse(aluno.DataNascimento, out var dataNascimento))
            {
                DataNascimento = dataNascimento;
            }
            else
            {
                throw new ArgumentException("Erro ao converter data de nascimento.");
            }

        }

        public void Update(Aluno aluno)
        {
            Nome = aluno.Nome;
            SobreNome = aluno.SobreNome;
            Idade = aluno.Idade;
            Genero = aluno.Genero;
            Telefone = aluno.Telefone;
            Email = aluno.Email;
            DataNascimento = aluno.DataNascimento;
        }
    }
}