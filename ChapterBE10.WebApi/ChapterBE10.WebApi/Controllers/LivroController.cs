using ChapterBE10.WebApi.Models;
using ChapterBE10.WebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChapterBE10.WebApi.Controllers
{
    [Produces("application/json")]//formato de resposta
    [Route("api/[controller]")]//api/Livro : rota para acesso da api
    [ApiController]//id que é um controller
    public class LivroController : ControllerBase
    {
        private readonly LivroRepository _livroRepository;

        public LivroController(LivroRepository livroRepository) 
        {
            _livroRepository = livroRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_livroRepository.Ler());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
