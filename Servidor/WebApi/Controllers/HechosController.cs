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
            string tiSueHead = Request.Headers["tip_sue"];
            if (string.IsNullOrEmpty(tiSueHead) || !int.TryParse(tiSueHead, out int tipoSuelo))
            {
                return -1;
            }
            return tipoSuelo;
        }
    }
}

/*

------------------------- DATOS DE PRUEBA -------------------------
Sedimentarios
{
  "presionGeologica": 175.3,
  "densidadDelSuelo": 2.6,
  "profundidadDeFisuras": 430.5,
  "indiceDeFracturamiento": 2.1,
  "profundidadDePerforacion": 370.2
}

{
  "presionGeologica": 210.7,
  "densidadDelSuelo": 2.8,
  "profundidadDeFisuras": 520.4,
  "indiceDeFracturamiento": 2.4,
  "profundidadDePerforacion": 470.1
}


Vertisoles
{
  "presionGeologica": 275.6,
  "densidadDelSuelo": 3.0,
  "profundidadDeFisuras": 340.2,
  "indiceDeFracturamiento": 2.7,
  "profundidadDePerforacion": 500.3
}

{
  "presionGeologica": 320.9,
  "densidadDelSuelo": 3.2,
  "profundidadDeFisuras": 480.1,
  "indiceDeFracturamiento": 2.9,
  "profundidadDePerforacion": 650.7
}

Residuales
{
  "concentracionElemento": 120.5,
  "contenidoMineral": 23.8,
  "conductividadElectrica": 5.2,
  "ph": 2.2,
  "temperatura": 75.6
}

{
  "concentracionElemento": 50.7,
  "contenidoMineral": 10.5,
  "conductividadElectrica": 6.9,
  "ph": 1.5,
  "temperatura": 42.3
}

Oxisoles
{
  "concentracionElemento": 180.3,
  "contenidoMineral": 27.2,
  "conductividadElectrica": 5.3,
  "ph": 3.5,
  "temperatura": 88.9
}

{
  "concentracionElemento": 8.2,
  "contenidoMineral": 2.5,
  "conductividadElectrica": 7.1,
  "ph": 0.9,
  "temperatura": 33.6
}

Lateritas
{
  "conductividadElectrica": 1.2,
  "intensidadMagnetica": 1.8,
  "porosidad": 27,
  "susceptibilidadMagnetica": 2.1,
  "contenidoMagnetico": 15
}

{
  "conductividadElectrica": 1.60,
  "intensidadMagnetica": 1.1,
  "porosidad": 22,
  "susceptibilidadMagnetica": 1.7,
  "contenidoMagnetico": 10
}

Glaciales
{
  "conductividadElectrica": 1.01,
  "intensidadMagnetica": 1.5,
  "porosidad": 18,
  "susceptibilidadMagnetica": 3.2,
  "contenidoMagnetico": 12
}

{
  "conductividadElectrica": 1.72,
  "intensidadMagnetica": 2.1,
  "porosidad": 14,
  "susceptibilidadMagnetica": 2.3,
  "contenidoMagnetico": 30
}

Andosoles
{
  "temperaturaGeotermica": 5.4,
  "flujoDeAgua": 280.0,
  "mineralizacion": 20.0,
  "presionHidrotermal": 240.0,
  "volumenHidrotermal": 45.0
}

{
  "temperaturaGeotermica": 6.1,
  "flujoDeAgua": 350.0,
  "mineralizacion": 23.0,
  "presionHidrotermal": 290.0,
  "volumenHidrotermal": 55.0
}

Entisoles
{
  "temperaturaGeotermica": 6.6,
  "flujoDeAgua": 310.0,
  "mineralizacion": 16.0,
  "presionHidrotermal": 190.0,
  "volumenHidrotermal": 40.0
}

{
  "temperaturaGeotermica": 5.8,
  "flujoDeAgua": 290.0,
  "mineralizacion": 12.0,
  "presionHidrotermal": 170.0,
  "volumenHidrotermal": 30.0
}

*/ 