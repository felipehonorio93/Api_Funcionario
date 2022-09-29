using FuncionariosApi.Data.Entities;
using FuncionariosApi.Data.Repositories;
using FuncionariosApi.Services.Request;
using FuncionariosApi.Services.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FuncionariosApi.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(FuncionariosPostRequest request)
        {
            try
            {
                var funcionario = new Funcionario()
                {
                    Nome = request.Nome,
                    Cpf = request.Cpf,
                    Matricula = request.Matricula,
                    DataAdmissao = request.DataAdmissao,
                };

                var funcionarioRepository = new FuncionarioRepository();
                funcionarioRepository.Create(funcionario);

                //HTTP 201 (CREATED)
                return StatusCode(201, new { mensagem = "Funcionário cadastrado com sucesso." });
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { mensagem = e.Message });
            }
        }

        [HttpPut]
        public IActionResult Put(FuncionariosPutRequest request)
        {
            try
            {
                var funcionarioRepository = new FuncionarioRepository();
                var funcionario = funcionarioRepository.GetById(request.IdFuncionario);

                if (funcionario == null)
                    return StatusCode(400, new { mensagem = "Funcionário não encontrado." });

                funcionario.Nome = request.Nome;
                funcionario.Cpf = request.Cpf;
                funcionario.Matricula = request.Matricula;
                funcionario.DataAdmissao = request.DataAdmissao;

                funcionarioRepository.Update(funcionario);

                //HTTP 200 (OK)
                return StatusCode(200, new { mensagem = "Funcionário atualizado com sucesso." });
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { mensagem = e.Message });
            }
        }

        [HttpDelete("{idFuncionario}")]
        public IActionResult Delete(Guid idFuncionario)
        {
            try
            {
                var funcionarioRepository = new FuncionarioRepository();
                var funcionario = funcionarioRepository.GetById(idFuncionario);

                if (funcionario == null)
                    return StatusCode(400, new { mensagem = "Funcionário não encontrado." });

                funcionarioRepository.Delete(funcionario);

                //HTTP 200 (OK)
                return StatusCode(200, new { mensagem = "Funcionário excluído com sucesso." });
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { mensagem = e.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var funcionarioRepository = new FuncionarioRepository();
                var funcionarios = funcionarioRepository.GetAll();

                //HTTP 200 (OK)
                return StatusCode(200, funcionarios);
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { mensagem = e.Message });
            }
        }

        [HttpGet("{idFuncionario}")]
        public IActionResult GetById(Guid idFuncionario)
        {
            try
            {
                var funcionarioRepository = new FuncionarioRepository();
                var funcionario = funcionarioRepository.GetById(idFuncionario);

                //HTTP 200 (OK)
                return StatusCode(200, funcionario);
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { mensagem = e.Message });
            }
        }
    }
}



