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
            double puntajeMaximo = double.MinValue;
            string mineralPredicho = string.Empty;
            foreach (var hecho in hSeleccionado)
            {
                double puntaje = CalcularCompatibilidad(datos, hecho.Value);
                if (puntaje > puntajeMaximo)
                {
                    puntajeMaximo = puntaje;
                    mineralPredicho = hecho.Key;
                }
            }
            if (string.IsNullOrEmpty(mineralPredicho))
            {
                return new BadRequestObjectResult("No se pudo predecir un mineral.");
            }
            return new OkObjectResult(new
            {
                mineral = mineralPredicho,
                puntaje = puntajeMaximo
            });
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
                // Calcular la diferencia absoluta normalizada
                return 1.0 / (1 + Math.Abs(val1 - val2));
            }
            return 0.0;
        }
    }
}