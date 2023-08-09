using SchoolAPI.DTO;

namespace SchoolAPI.Interfaces.Services
{
    public interface IAutenticacaoServices
    {
        string Autenticar(LoginDTO login);
    }
}
