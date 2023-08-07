namespace SchoolAPI.Models
{
    public class NotasMaterias
    {
        public int Id { get; set; }
        public Boletim Boletim { get; set; }
        public int BoletimId { get; set; }
        public Materia Materia { get; set; }
        public int MateriaId { get; set; }
        public int Nota { get; set; }
    }
}
