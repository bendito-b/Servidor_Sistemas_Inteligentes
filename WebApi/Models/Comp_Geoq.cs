namespace WebApi.Models
{
    public class Comp_Geoq
    {
        public double ElementosTraza { get; set; }
        public double ConcentracionOxidosMetalicos { get; set; }
        public double pH { get; set; }
        public double ConductividadIonica { get; set; }
        public double GradoMeteorizacion { get; set; }

        public Comp_Geoq(double ElementosTraza, double concentracionOxidosMetalicos, double pH, double conductividadIonica, double gradoMeteorizacion)
        {
            this.ElementosTraza = ElementosTraza;
            this.ConcentracionOxidosMetalicos = concentracionOxidosMetalicos;
            this.pH = pH;
            this.ConductividadIonica = conductividadIonica;
            this.GradoMeteorizacion = gradoMeteorizacion;
        }
    }
}