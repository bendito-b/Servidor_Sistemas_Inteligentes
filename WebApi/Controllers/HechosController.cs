using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HechosController : ControllerBase
    {
        private readonly Hechos hechos;
        // Constructor donde inyectamos la clase BaseDeConocimientos
        public HechosController(Hechos h)
        {
            hechos = h;
        }

        // Método de ejemplo donde podemos usar las listas en la lógica
        [HttpGet("index")]
        public IActionResult Index()
        {
            // Ejemplo de cómo puedes usar las listas para realizar operaciones internas
            var totalPlomo = hechos.Sedimentarios[0].DensidadDelSuelo + hechos.Vertisoles[0].DensidadDelSuelo;

            // Aquí, puedes hacer cualquier operación que necesites usando las listas internas.
            // Luego puedes devolver un mensaje con el resultado de esas operaciones o de cualquier lógica interna.
            return Ok(new
            {
                mensaje = "Bienvenido a la API",
                totalPlomo = totalPlomo
            });
        }

        // Ejemplo de otra solicitud donde se utiliza el valor de la lista
        [HttpGet("operacion")]
        public IActionResult Operacion()
        {
            // Usar las listas para realizar algún tipo de cálculo
            var sumaResiduales = hechos.Residuales[0].pH + hechos.Residuales[1].pH;

            return Ok(new
            {
                resultadoOperacion = sumaResiduales
            });
        }
    }
}
