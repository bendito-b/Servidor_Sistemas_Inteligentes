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
        public HechosController(Hechos h)
        {
            hechos = h;
        }

        // MOTOR DE INFERENCIA : ACTIVIDAD GEOMECÁNICA
        [HttpPost("ActividadGeomecanica")]
        public IActionResult ActividadGeomecanica([FromBody] Act_Geome datos)
        {
            int tiSue = ObtenerTipoSuelo();
            if (tiSue == -1)
            {
                return BadRequest("Tipo de suelo no proporcionado.");
            }
            var hTiSue = new Dictionary<int, Dictionary<string, Act_Geome>>()
            {
                { 1, hechos.Sedimentarios },
                { 2, hechos.Vertisoles }
            };
            var hSelec = MotorInferencia.SeleccionarHechos(tiSue, hTiSue);
            return MotorInferencia.CalcularInferencia(datos, hSelec);
        }

        // MOTOR DE INFERENCIA : COMPOSICIÓN GEOQUÍMICA
        [HttpPost("ComposicionGeoquimica")]
        public IActionResult ComposicionGeoquimica([FromBody] Comp_Geoq datos)
        {
            int tiSue = ObtenerTipoSuelo();
            if (tiSue == -1)
            {
                return BadRequest("Tipo de suelo no proporcionado.");
            }
            var hTiSue = new Dictionary<int, Dictionary<string, Comp_Geoq>>()
            {
                { 1, hechos.Residuales },
                { 2, hechos.Oxisoles }
            };
            var hSelec = MotorInferencia.SeleccionarHechos(tiSue, hTiSue);
            return MotorInferencia.CalcularInferencia(datos, hSelec);
        }

        // MOTOR DE INFERENCIA : CONDUCTIVIDAD Y MAGNETISMO
        [HttpPost("ConductividadMagnetismo")]
        public IActionResult ConductividadMagnetismo([FromBody] Cond_Magne datos)
        {
            int tiSue = ObtenerTipoSuelo();
            if (tiSue == -1)
            {
                return BadRequest("Tipo de suelo no proporcionado.");
            }
            var hTiSue = new Dictionary<int, Dictionary<string, Cond_Magne>>()
            {
                { 1, hechos.Lateritas },
                { 2, hechos.Glaciales }
            };
            var hSelec = MotorInferencia.SeleccionarHechos(tiSue, hTiSue);
            return MotorInferencia.CalcularInferencia(datos, hSelec);
        }

        // MOTOR DE INFERENCIA : POTENCIAL HIDROTERMAL
        [HttpPost("PotencialHidrotermal")]
        public IActionResult PotencialHidrotermal([FromBody] Pot_Hidro datos)
        {
            int tiSue = ObtenerTipoSuelo();
            if (tiSue == -1)
            {
                return BadRequest("Tipo de suelo no proporcionado.");
            }
            var hTiSue = new Dictionary<int, Dictionary<string, Pot_Hidro>>()
            {
                { 1, hechos.Andosoles },
                { 2, hechos.Entisoles }
            };
            var hSelec = MotorInferencia.SeleccionarHechos(tiSue, hTiSue);
            return MotorInferencia.CalcularInferencia(datos, hSelec);
        }

        private int ObtenerTipoSuelo()
        {
            //string tiSueHead = Request.Headers["tip_sue"];
            string tiSueHead = "1";
            if (string.IsNullOrEmpty(tiSueHead) || !int.TryParse(tiSueHead, out int tipoSuelo))
            {
                return -1;
            }
            return tipoSuelo;
        }
    }
}
