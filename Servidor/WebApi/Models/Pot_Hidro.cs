namespace WebApi.Models
{
    public class Pot_Hidro
    {
        public double pH { get; set; }
        public double Temperatura { get; set; }
        public double Porosidad { get; set; }
        public double AguaSubterranea { get; set; }
        public double AlteracionHidrotermal { get; set; }

        public Pot_Hidro(double pH, double temperatura, double porosidad, double aguaSubterranea, double alteracionHidrotermal)
        {
            this.pH = pH;
            this.Temperatura = temperatura;
            this.Porosidad = porosidad;
            this.AguaSubterranea = aguaSubterranea;
            this.AlteracionHidrotermal = alteracionHidrotermal;
        }
    }
}
