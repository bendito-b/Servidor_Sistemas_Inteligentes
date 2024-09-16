using AccesoDatos_Proyecto_SistemasInteligentes.Models;
using AccesoDatos_Proyecto_SistemasInteligentes.Operaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public UsuarioDAO usuarioDAO = new UsuarioDAO();

        [HttpPost("autenticar")]
        public IActionResult iniciarSesion([FromBody] Usuario usuario)
        {
            var resultado = usuarioDAO.validar(usuario.LogiUsuario, usuario.PassUsuario);

            if (resultado != null)
            {
                // el término "ok" devuelve como respuesta HTTP 200
                return Ok(new { usuario = resultado.NombUsuario });
            }
            else
            {
                // el término "Unauthorized" devuelve como respuesta HTTP 401
                return Unauthorized();
            }
        }
    }
}
