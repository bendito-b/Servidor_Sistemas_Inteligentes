using AccesoDatos_Proyecto_SistemasInteligentes.Operaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    //Esto es un cambio...

    [Route("api")]
    [ApiController]
    public class PruebaController : ControllerBase
    {
        private readonly UsuarioDAO dao = new UsuarioDAO();

      
        [HttpGet("Listar")]
        public IActionResult Listar()

        {
            try
            {
                var usuarios = dao.listartodos(); 
                if (usuarios == null || usuarios.Count == 0)
                {
                    return NotFound("No se encontraron usuarios.");
                }
                return Ok(usuarios); 
            }
            catch (Exception ex)
            {
            
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los usuarios: " + ex.Message);
            }
        }
    }
}
