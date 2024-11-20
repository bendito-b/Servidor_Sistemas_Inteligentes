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

        // MOTOR DE INFERENCIA
        [HttpPost("ActividadGeomecanica")]
        public IActionResult ActividadGeomecanica([FromBody] Act_Geome datos)
        {
            // Obtener el tipo de suelo desde los encabezados HTTP
            //string tipoSueloHead = Request.Headers["tip_sue"];
            string tipoSueloHead = "1";

            // Asegurarse de que el encabezado esté presente y es válido
            if (string.IsNullOrEmpty(tipoSueloHead) || !int.TryParse(tipoSueloHead, out int tipoSuelo))
            {
                return BadRequest("Tipo de suelo no proporcionado o inválido.");
            }

            // Crear un diccionario para almacenar los puntajes de cada mineral
            Dictionary<string, double> puntajes = new Dictionary<string, double>();

            // Elegir el conjunto de hechos correspondiente según el tipo de suelo
            List<Act_Geome> hechosSeleccionados = tipoSuelo switch
            {
                1 => hechos.Sedimentarios, // Si tipo_suelo es 1, usamos los Sedimentarios
                2 => hechos.Vertisoles,    // Si tipo_suelo es 2, usamos los Vertisoles
                _ => new List<Act_Geome>() // Si no es 1 ni 2, no seleccionamos ningún tipo válido
            };

            // Si no se seleccionó un conjunto de hechos válido
            if (!hechosSeleccionados.Any())
            {
                return BadRequest("Tipo de suelo no válido.");
            }

            // Evaluar la compatibilidad con cada grupo de minerales en la base de hechos (Hechos)
            double puntajeMaximo = double.MinValue;
            string mineralPredicho = string.Empty;

            foreach (var hecho in hechosSeleccionados)
            {
                // Calcular puntajes de compatibilidad para el mineral
                double puntaje = CalcularCompatibilidad(datos, hecho);

                // Si el puntaje es el mayor hasta ahora, actualizamos el mineral predicho
                if (puntaje > puntajeMaximo)
                {
                    puntajeMaximo = puntaje;
                    mineralPredicho = ObtenerMineral(hecho); // Esta función puede devolver el nombre del mineral asociado con el hecho
                }
            }

            // Si no se predijo ningún mineral
            if (string.IsNullOrEmpty(mineralPredicho))
            {
                return BadRequest("No se pudo predecir un mineral.");
            }

            // Retornar el mineral predicho y su puntaje
            return Ok(new
            {
                mineral = mineralPredicho,
                puntaje = puntajeMaximo
            });
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

        private double CalcularCompatibilidad(Act_Geome datosUsuario, Act_Geome hecho)
        {
            double puntaje = 0.0;

            // Comparar propiedades clave, por ejemplo, usando una fórmula de diferencia normalizada o alguna otra estrategia
            puntaje += CompararPropiedades(datosUsuario.PresionGeologica, hecho.PresionGeologica);
            puntaje += CompararPropiedades(datosUsuario.DensidadDelSuelo, hecho.DensidadDelSuelo);
            puntaje += CompararPropiedades(datosUsuario.ProfundidadDeFisuras, hecho.ProfundidadDeFisuras);
            puntaje += CompararPropiedades(datosUsuario.IndiceDeFracturamiento, hecho.IndiceDeFracturamiento);
            puntaje += CompararPropiedades(datosUsuario.ProfundidadDePerforacion, hecho.ProfundidadDePerforacion);

            return puntaje;
        }

        // Método para comparar dos valores y calcular su "compatibilidad" (por ejemplo, mediante una normalización de la diferencia)
        private double CompararPropiedades(double valorUsuario, double valorHecho)
        {
            // La diferencia absoluta puede ser un simple método de comparación
            return 1.0 / (1 + Math.Abs(valorUsuario - valorHecho));
        }
        private string ObtenerMineral(Act_Geome hecho)
        {
            // Se asignan los minerales en base a los valores de las propiedades
            if (hecho.PresionGeologica == 2000.0 && hecho.DensidadDelSuelo == 2.6)
                return "Plomo";
            if (hecho.PresionGeologica == 2200.0 && hecho.DensidadDelSuelo == 2.7)
                return "Zinc";
            if (hecho.PresionGeologica == 2400.0 && hecho.DensidadDelSuelo == 2.9)
                return "Tungsteno";
            if (hecho.PresionGeologica == 1500.0 && hecho.DensidadDelSuelo == 2.3)
                return "Carbón";
            return "Desconocido";  // En caso de no encontrar el mineral
        }
    }
}
