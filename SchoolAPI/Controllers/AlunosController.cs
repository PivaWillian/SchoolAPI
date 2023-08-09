using SchoolAPI.DTO;
using SchoolAPI.Exceptions;
using SchoolAPI.Interfaces.Services;
using SchoolAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SchoolAPI.DTO;
using SchoolAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunosController : ControllerBase
    {
        private readonly IAlunoService _alunoService;
        private readonly IMemoryCache _memoryCache;

        public AlunosController(IAlunoService alunoService, IMemoryCache memoryCache)
        {
            _alunoService = alunoService;
            _memoryCache = memoryCache;
        }

        [HttpPost]
        [Authorize(Roles = "Professor")]
        public IActionResult Post([FromBody] AlunoDTO alunoDTO)
        {
            var aluno = new Aluno(alunoDTO);
            //Chamada da service
            aluno = _alunoService.Criar(aluno);

            return Ok(new AlunoDTO(aluno));
        }

        [HttpGet]
        [Authorize(Roles = "Professor,Aluno")]
        public ActionResult<AlunoDTO> Get()
        {

            var alunos = _alunoService.ObterAlunos();
            IEnumerable<AlunoDTO> alunosDtos = alunos.Select(x => new AlunoDTO(x));
            return Ok(alunosDtos);

        }


        [HttpGet]
        [Authorize(Roles = "Professor,Aluno")]
        [Route("{id}")]
        public IActionResult GetComId([FromRoute] int id)
        {
            AlunoDTO aluno;
            if (!_memoryCache.TryGetValue<AlunoDTO>($"aluno:{id}", out aluno))
            {
                aluno = new AlunoDTO(_alunoService.ObterPorId(id));
                _memoryCache.Set<AlunoDTO>($"aluno:{id}", aluno, new TimeSpan(0, 0, 20));
            }
            return Ok(aluno);

        }


        [HttpPut]
        [Authorize(Roles = "Professor")]
        [Route("{id}")]
        public IActionResult AtualizaAluno([FromBody] AlunoDTO alunoDTO, [FromRoute] int id)
        {

            var aluno = new Aluno(alunoDTO);
            aluno.Id = id;
            if (!ModelState.IsValid) return BadRequest("Dados inválidos, favor verificar o formato obrigatório dos dados!");

            aluno = _alunoService.Atualizar(aluno);

            //var alunodto = new AlunoDTO(aluno);
            //_memoryCache.Set<AlunoDTO>($"aluno:{id}", alunodto, new TimeSpan(0, 0, 20));

            _memoryCache.Remove($"aluno:{id}");

            return Ok(new AlunoDTO(aluno));

        }

        [HttpDelete]
        [Authorize(Roles = "Professor")]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            _alunoService.DeletarAluno(id);
            _memoryCache.Remove($"aluno:{id}");

            return StatusCode(204);
        }
    }
}