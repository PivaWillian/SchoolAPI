namespace SchoolAPI.Models
{
    public class Materia
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<NotasMaterias> NotasMaterias { get; set; }
    }
}