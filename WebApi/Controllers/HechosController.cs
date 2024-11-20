using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HechosController : ControllerBase
    {
        [HttpGet("saludo")]
        public IActionResult Saludo()
        {
            return Ok(new { mensaje = "hola" });
        }

        [HttpGet("index")]
        public IActionResult Index()
        {
            return Ok(new { mensaje = "Bienvenido a la API" });
        }

        //BASE DE CONOCIMIENTOS : HECHOS
        public List<Act_Geome> Sedimentarios()
        {
            Act_Geome pbSed = new Act_Geome(2000.0, 2.6, 350.0, 2.0, 300.0); // Plomo
            Act_Geome znSed = new Act_Geome(2200.0, 2.7, 400.0, 2.2, 350.0); // Zinc
            Act_Geome wSed = new Act_Geome(2400.0, 2.9, 500.0, 2.3, 400.0); // Tungsteno
            Act_Geome cSed = new Act_Geome(1500.0, 2.3, 250.0, 1.5, 200.0); // Carbón
            return new List<Act_Geome> { pbSed, znSed, wSed, cSed };
        }

        public List<Act_Geome> Vertisoles()
        {
            Act_Geome pbVer = new Act_Geome(3000.0, 3.1, 250.0, 2.5, 450.0); // Plomo
            Act_Geome znVer = new Act_Geome(2800.0, 3.2, 300.0, 2.3, 400.0); // Zinc
            Act_Geome wVer = new Act_Geome(3500.0, 3.4, 350.0, 2.8, 500.0); // Tungsteno
            Act_Geome cVer = new Act_Geome(2200.0, 2.7, 150.0, 1.8, 300.0); // Carbón
            return new List<Act_Geome> { pbVer, znVer, wVer, cVer };
        }

        public List<Comp_Geoq> Residuales()
        {
            Comp_Geoq snRes = new Comp_Geoq(30.0, 12.0, 5.5, 1.2, 50.0); // Estaño
            Comp_Geoq wRes = new Comp_Geoq(40.0, 15.0, 5.2, 1.5, 60.0); // Tungsteno
            Comp_Geoq cRes = new Comp_Geoq(25.0, 10.0, 6.0, 0.8, 70.0); // Carbón
            return new List<Comp_Geoq> { snRes, wRes, cRes };
        }

        public List<Comp_Geoq> Oxisoles()
        {
            Comp_Geoq snOxi = new Comp_Geoq(80.0, 30.0, 4.8, 2.5, 85.0); // Estaño
            Comp_Geoq wOxi = new Comp_Geoq(100.0, 40.0, 4.5, 3.0, 80.0); // Tungsteno
            Comp_Geoq cOxi = new Comp_Geoq(60.0, 25.0, 5.0, 2.0, 75.0); // Carbón
            return new List<Comp_Geoq> { snOxi, wOxi, cOxi };
        }

        public List<Cond_Magne> Lateritas()
        {
            Cond_Magne cuLat = new Cond_Magne(50.0, 3.5, 30.0, 15.0, 50.0); // Cobre
            Cond_Magne feLat = new Cond_Magne(30.0, 4.5, 35.0, 18.0, 55.0); // Hierro
            return new List<Cond_Magne> { cuLat, feLat };
        }

        public List<Cond_Magne> Glaciales()
        {
            Cond_Magne cuGla = new Cond_Magne(150.0, 2.5, 15.0, 10.0, 25.0); // Cobre
            Cond_Magne feGla = new Cond_Magne(100.0, 3.5, 18.0, 12.0, 35.0); // Hierro
            return new List<Cond_Magne> { cuGla, feGla };
        }

        public List<Pot_Hidro> Andosoles()
        {
            Pot_Hidro cuAndo = new Pot_Hidro(6.1, 200.0, 45.0, 30.0, 65.0); // Cobre
            Pot_Hidro auAndo = new Pot_Hidro(6.4, 220.0, 40.0, 35.0, 70.0); // Oro
            Pot_Hidro agAndo = new Pot_Hidro(5.6, 210.0, 42.0, 32.0, 60.0); // Plata
            Pot_Hidro wAndo = new Pot_Hidro(5.9, 230.0, 50.0, 28.0, 75.0); // Tungsteno
            return new List<Pot_Hidro> { cuAndo, auAndo, agAndo, wAndo };
        }

        public List<Pot_Hidro> Entisoles()
        {
            Pot_Hidro cuEnti = new Pot_Hidro(6.2, 120.0, 35.0, 30.0, 35.0); // Cobre
            Pot_Hidro auEnti = new Pot_Hidro(6.8, 130.0, 30.0, 33.0, 40.0); // Oro
            Pot_Hidro agEnti = new Pot_Hidro(6.5, 110.0, 32.0, 31.0, 38.0); // Plata
            Pot_Hidro wEnti = new Pot_Hidro(6.0, 140.0, 40.0, 29.0, 42.0); // Tungsteno
            return new List<Pot_Hidro> { cuEnti, auEnti, agEnti, wEnti };
        }
    }
}
