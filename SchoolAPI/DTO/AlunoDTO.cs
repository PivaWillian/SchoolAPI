using SchoolAPI.Models;

namespace SchoolAPI.DTO
{
    public class AlunoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SobreNome { get; set; }
        public int Idade { get; set; }
        public string Genero { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string DataNascimento { get; set; }

        public AlunoDTO()
        {

        }

        public AlunoDTO(Aluno aluno)
        {
            Id = aluno.Id;
            Name = aluno.Name;
            SobreNome = aluno.SobreNome;
            Idade = aluno.Idade;
            Genero = aluno.Genero;
            Telefone = aluno.Telefone;
            Email = aluno.Email;
            DataNascimento = aluno.DataNascimento.ToString("dd/MM/yy");
        }
    }
}