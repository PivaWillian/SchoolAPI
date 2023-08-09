using SchoolAPI.DTO;
using SchoolAPI.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace SchoolAPI.Controllers
{
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {

        private readonly IAutenticacaoServices _autenticacaoServices;
        public AutenticacaoController(IAutenticacaoServices autenticacaoServices)
        {
            _autenticacaoServices = autenticacaoServices;
        }
        [HttpPost("/login")]
        [AllowAnonymous]
        public ActionResult Logar(LoginDTO loginDTO)
        {
            return Ok(new { token = _autenticacaoServices.Autenticar(loginDTO) });
        }
    }
}