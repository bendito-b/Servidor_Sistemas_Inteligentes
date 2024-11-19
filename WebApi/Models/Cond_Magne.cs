namespace WebApi.Models
{
    public class Cond_Magne
    {
        public double ResistividadElectrica { get; set; }
        public double Magnetismo { get; set; }
        public string SaturacionDeAgua { get; set; }
        public double SusceptibilidadMagnetica { get; set; }
        public double ContenidoOxidosMetalicos { get; set; }

        public Cond_Magne(double resistividadElectrica, double magnetismo, string saturacionDeAgua, double susceptibilidadMagnetica, double contenidoOxidosMetalicos)
        {
            this.ResistividadElectrica = resistividadElectrica;
            this.Magnetismo = magnetismo;
            this.SaturacionDeAgua = saturacionDeAgua;
            this.SusceptibilidadMagnetica = susceptibilidadMagnetica;
            this.ContenidoOxidosMetalicos = contenidoOxidosMetalicos;
        }
    }
}