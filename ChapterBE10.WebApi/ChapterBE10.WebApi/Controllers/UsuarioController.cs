using ChapterBE10.WebApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChapterBE10.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _iUsuarioRepository;
        public UsuarioController(IUsuarioRepository iUsuarioRepository) 
        {
            _iUsuarioRepository= iUsuarioRepository;
        }

        [HttpGet]
 
        public IActionResult ListarUsuario()
        {
            try
            {
                return Ok(_iUsuarioRepository.Listar());
                
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        //public IActionResult
        //{

        //}





}
}
