using CrudDapperVideo.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudDapperVideo.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioInterface _usuarioInterface;
        public UsuarioController(IUsuarioInterface usuarioInterface) 
        {
            _usuarioInterface = usuarioInterface;
        }

        [HttpGet]
        public async Task<IActionResult>BuscarUsuarios()
        {
            var usuarios = await _usuarioInterface.BuscarUsuarios();

            if(usuarios.Status == false)
            {
                return NotFound(usuarios);
            }
            return Ok(usuarios);
        }
    }
}
