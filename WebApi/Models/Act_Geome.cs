namespace WebApi.Models
{
    public class Act_Geome
    {
        public double PresionGeologica { get; set; }
        public double DensidadDelSuelo { get; set; }
        public double ProfundidadDeFisuras { get; set; }
        public double IndiceDeFracturamiento { get; set; }
        public double ProfundidadDePerforacion { get; set; }

        public Act_Geome(double presionGeologica, double densidadDelSuelo, double profundidadDeFisuras, double indiceDeFracturamiento, double profundidadDePerforacion)
        {
            this.PresionGeologica = presionGeologica;
            this.DensidadDelSuelo = densidadDelSuelo;
            this.ProfundidadDeFisuras = profundidadDeFisuras;
            this.IndiceDeFracturamiento = indiceDeFracturamiento;
            this.ProfundidadDePerforacion = profundidadDePerforacion;
        }
    }
}