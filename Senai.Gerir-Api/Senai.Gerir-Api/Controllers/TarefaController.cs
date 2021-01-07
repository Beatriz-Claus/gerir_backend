using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Senai.Gerir.Api.Dominios;
using Senai.Gerir.Api.Interfaces;
using Senai.Gerir.Api.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gerir.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TarefaController : ControllerBase 
    {
        private readonly ITarefasRepositorio _tarefaRepositorio;

        public TarefaController()
        {
            _tarefaRepositorio = new TarefasRepositorio();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Cadastrar(Tarefa tarefa)
        {
            try
            {

                var usuarioid = HttpContext.User.Claims.FirstOrDefault(
                                c => c.Type == JwtRegisteredClaimNames.Jti
                               );
                tarefa.Usuario.Id = new System.Guid(usuarioid.Value);

                _tarefaRepositorio.Cadastrar(tarefa);

                return Ok(tarefa);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[Authorize]
        [HttpDelete("{IdTarefa}")]
        public IActionResult Remover(Guid IdTarefa)
        {
            try
            {
               
                _tarefaRepositorio.Remover(IdTarefa);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut]
        public IActionResult Editar(Tarefa tarefa)
        {
            try
            {
                //Envia para o metodo editar os dados da tarefa recebido
                _tarefaRepositorio.Editar(tarefa);

                return Ok(tarefa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut("AlterarStatus/{idTarefa}")]
        public IActionResult AlterarStatus(Guid IdTarefa)
        {
            try
            {

                var tarefa = _tarefaRepositorio.AlterarStatus(IdTarefa);

                return Ok(tarefa);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }  
        
        //[Authorize]
        [HttpGet("Buscar/{id}")]
        public IActionResult Buscar(Guid IdTarefa)
        {
            try
            {
                //Pega as informações da tarefa a partir do seu ID

                var usuarioid = HttpContext.User.Claims.FirstOrDefault(
                                c => c.Type == JwtRegisteredClaimNames.Jti
                               );

                //Busca uma tarefa pelo seu id
                var tarefa = _tarefaRepositorio.BuscarPorId(IdTarefa);

                //Verifica se a tarefa existe
                if (tarefa == null)
                    return NotFound();

                //Verifica se a tarefa é do usuario logado
                if (tarefa.UsuarioId != new Guid(usuarioid.Value))
                    return Unauthorized("Usuário não tem permissão");

                return Ok(tarefa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Authorize]
        [HttpGet]

        public IActionResult ListarTodos()
        {
            try
            {
                //Pega o valor do usuário que esta logado
                var usuarioid = HttpContext.User.Claims.FirstOrDefault(
                                c => c.Type == JwtRegisteredClaimNames.Jti
                            );

                var tarefas = _tarefaRepositorio.Listar(
                                    new System.Guid(usuarioid.Value)
                              );

                return Ok(tarefas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
