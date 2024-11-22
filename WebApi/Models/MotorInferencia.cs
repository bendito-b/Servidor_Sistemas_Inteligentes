using Microsoft.AspNetCore.Mvc;

namespace WebApi.Models
{
    public class MotorInferencia
    {
        // REGLA HECHOS : Selecciona el tipo de suelo
        public static Dictionary<string, T> SeleccionarHechos<T>(int tipoSuelo, Dictionary<int, Dictionary<string, T>> hTipoSuelo)
        {
            if (!hTipoSuelo.ContainsKey(tipoSuelo))
            {
                return new Dictionary<string, T>();
            }
            return hTipoSuelo[tipoSuelo];
        }

        // Calculo del nivel de la compatibilidad entre los datos y los hechos
        public static IActionResult CalcularInferencia<T>(T datos, Dictionary<string, T> hSeleccionado)
        {
            if (hSeleccionado.Count == 0)
            {
                return new BadRequestObjectResult("Tipo de suelo no válido.");
            }
            // Diccionario para almacenar puntajes de compatibilidad de cada mineral
            Dictionary<string, double> pMineral = new Dictionary<string, double>();
            foreach (var hecho in hSeleccionado)
            {
                // Compara los datos del usuario con los hechos de cada mineral
                double puntaje = CalcularCompatibilidad(datos, hecho.Value);
                pMineral[hecho.Key] = puntaje;
            }
            if (pMineral.Count == 0)
            {
                return new BadRequestObjectResult("No se pudo predecir un mineral.");
            }
            double pTotal = pMineral.Values.Sum();
            if (pTotal == 0)
            {
                return new BadRequestObjectResult("Los puntajes calculados son 0, no se puede determinar la probabilidad.");
            }
            // Ordena según los puntajes de compatibilidad y calcula la probabilidad porcentual
            var resPorcentaje = pMineral
                .OrderByDescending(kvp => kvp.Value)
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => Math.Round((kvp.Value / pTotal) * 100, 2)
                );
            var minOrdernado = resPorcentaje
                .Select(kvp => new
                {
                    mineral = kvp.Key,
                    probabilidad = kvp.Value
                })
                .ToList();
            return new OkObjectResult(minOrdernado); // Resultado con las probabilidades de los minerales más abundantes.
        }

        // REGLA COMPATIBILIDAD : Realiza el cálculo del puntaje
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

        // REGLA COMPARACIÓN : Coteja las características para obtener la compatibilidad
        private static double CompararPropiedades(object valorDatos, object valorHecho)
        {
            if (valorDatos is IComparable comparableDatos && valorHecho is IComparable comparableHecho)
            {
                double val1 = Convert.ToDouble(valorDatos);
                double val2 = Convert.ToDouble(valorHecho);
                return Math.Exp(-Math.Abs(val1 - val2) * 2); // Deducción: Similitud de valores se traduce en una mayor compatibilidad.
            }
            return 0.0;
        }
    }
}