using SchoolAPI.Models;

namespace SchoolAPI.DTO
{
    public class BoletimDTO
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int AlunoId { get; set; }


        public BoletimDTO()
        {

        }
        public BoletimDTO(Boletim boletim)
        {

            Id = boletim.Id;
            Data = boletim.Data;
            AlunoId = boletim.AlunoId;
        }
    }
}
