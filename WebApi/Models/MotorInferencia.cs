using Microsoft.AspNetCore.Mvc;

namespace WebApi.Models
{
    public class MotorInferencia
    {
        public static Dictionary<string, T> SeleccionarHechos<T>(int tipoSuelo, Dictionary<int, Dictionary<string, T>> hechosPorTipoSuelo)
        {
            if (!hechosPorTipoSuelo.ContainsKey(tipoSuelo))
            {
                return new Dictionary<string, T>();
            }
            return hechosPorTipoSuelo[tipoSuelo];
        }

        public static IActionResult CalcularInferencia<T>(T datos, Dictionary<string, T> hSeleccionado)
        {
            if (hSeleccionado.Count == 0)
            {
                return new BadRequestObjectResult("Tipo de suelo no válido.");
            }
            Dictionary<string, double> puntajesMinerales = new Dictionary<string, double>();
            foreach (var hecho in hSeleccionado)
            {
                double puntaje = CalcularCompatibilidad(datos, hecho.Value);
                puntajesMinerales[hecho.Key] = puntaje;
            }
            if (puntajesMinerales.Count == 0)
            {
                return new BadRequestObjectResult("No se pudo predecir un mineral.");
            }
            double puntajeTotal = puntajesMinerales.Values.Sum();
            if (puntajeTotal == 0)
            {
                return new BadRequestObjectResult("Los puntajes calculados son 0, no se puede determinar la probabilidad.");
            }
            var resultadosPorcentaje = puntajesMinerales
                .OrderByDescending(kvp => kvp.Value)
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => Math.Round((kvp.Value / puntajeTotal) * 100, 2)
                );
            var mineralesOrdenados = resultadosPorcentaje
                .Select(kvp => new
                {
                    mineral = kvp.Key,
                    probabilidad = kvp.Value
                })
                .ToList();
            return new OkObjectResult(mineralesOrdenados);
        }

        private static double CalcularCompatibilidad<T>(T datos, T hecho)
        {
            double puntaje = 0.0;
            var propiedades = typeof(T).GetProperties();
            foreach (var propiedad in propiedades)
            {
                var valorDatos = propiedad.GetValue(datos);
                var valorHecho = propiedad.GetValue(hecho);
                if (valorDatos is IComparable && valorHecho is IComparable)
                {
                    puntaje += CompararPropiedades(valorDatos, valorHecho);
                }
            }
            return puntaje;
        }

        private static double CompararPropiedades(object valorDatos, object valorHecho)
        {
            if (valorDatos is IComparable comparableDatos && valorHecho is IComparable comparableHecho)
            {
                double val1 = Convert.ToDouble(valorDatos);
                double val2 = Convert.ToDouble(valorHecho);
                // Penaliza fuertemente las grandes diferencias, enfatiza más las similitudes
                return Math.Exp(-Math.Abs(val1 - val2) * 2);
            }
            return 0.0;
        }
    }
}