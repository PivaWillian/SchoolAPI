namespace SchoolAPI.Models
{
    public class AlunoTurma
    {
        public virtual Aluno Aluno { get; set; }
        public virtual Turma Turma { get; set; }

        public int AlunoId { get; set; }
        public int TurmaId { get; set; }

    }
}
