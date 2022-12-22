using ChapterBE10.WebApi.Interfaces;
using ChapterBE10.WebApi.Models;
using ChapterBE10.WebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChapterBE10.WebApi.Controllers
{

    [Produces("application/json")] //formato de resposta
    [Route("api/[controller]")]//api/Livro : rota para acesso da api
    [ApiController]//id que é um controller
    public class LivroController : ControllerBase
    {
        private readonly ILivroRepository _ILivroRepository;

        public LivroController(ILivroRepository iLivroRepository)
        {
            _ILivroRepository = iLivroRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_ILivroRepository.Ler());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Livro livro)
        {
            try
            {
                _ILivroRepository.Cadstrar(livro);
                return Ok(livro);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(int id, Livro livro)
        {
            try
            {
                _ILivroRepository.Atualizar(id, livro);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _ILivroRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                Livro livro = _ILivroRepository.BuscarPorId(id);

                if (livro == null)
                {
                    return NotFound();
                }
                return Ok(livro);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet("titulo/{titulo}")]
        public IActionResult GetByTitle(string titulo)
        {
            try
            {
                Livro livro = _ILivroRepository.BuscarPorTitulo(titulo);

                if (livro == null)
                {
                    return NotFound();
                }
                return Ok(livro);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
