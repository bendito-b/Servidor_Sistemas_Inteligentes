namespace WebApi.Models
{
    public class Hechos
    {
        // Declaración de listas como propiedades
        public List<Act_Geome> Sedimentarios { get; private set; }
        public List<Act_Geome> Vertisoles { get; private set; }
        public List<Comp_Geoq> Residuales { get; private set; }
        public List<Comp_Geoq> Oxisoles { get; private set; }
        public List<Cond_Magne> Lateritas { get; private set; }
        public List<Cond_Magne> Glaciales { get; private set; }
        public List<Pot_Hidro> Andosoles { get; private set; }
        public List<Pot_Hidro> Entisoles { get; private set; }

        // Constructor para inicializar las listas
        public Hechos()
        {
            // Inicialización de las listas

            //ACTIVIDAD GEOMECÁNICA
            Sedimentarios = new List<Act_Geome>
            {
                new Act_Geome(2000.0, 2.6, 350.0, 2.0, 300.0), // Plomo
                new Act_Geome(2200.0, 2.7, 400.0, 2.2, 350.0), // Zinc
                new Act_Geome(2400.0, 2.9, 500.0, 2.3, 400.0), // Tungsteno
                new Act_Geome(1500.0, 2.3, 250.0, 1.5, 200.0)  // Carbón
            };

            Vertisoles = new List<Act_Geome>
            {
                new Act_Geome(3000.0, 3.1, 250.0, 2.5, 450.0), // Plomo
                new Act_Geome(2800.0, 3.2, 300.0, 2.3, 400.0), // Zinc
                new Act_Geome(3500.0, 3.4, 350.0, 2.8, 500.0), // Tungsteno
                new Act_Geome(2200.0, 2.7, 150.0, 1.8, 300.0)  // Carbón
            };

            //COMPOSICIÓN GEOQUÍMICA
            Residuales = new List<Comp_Geoq>
            {
                new Comp_Geoq(30.0, 12.0, 5.5, 1.2, 50.0), // Estaño
                new Comp_Geoq(40.0, 15.0, 5.2, 1.5, 60.0), // Tungsteno
                new Comp_Geoq(25.0, 10.0, 6.0, 0.8, 70.0)  // Carbón
            };

            Oxisoles = new List<Comp_Geoq>
            {
                new Comp_Geoq(80.0, 30.0, 4.8, 2.5, 85.0), // Estaño
                new Comp_Geoq(100.0, 40.0, 4.5, 3.0, 80.0), // Tungsteno
                new Comp_Geoq(60.0, 25.0, 5.0, 2.0, 75.0)  // Carbón
            };
            
            //CONDUCTIVIDAD Y MAGNETISMO
            Lateritas = new List<Cond_Magne>
            {
                new Cond_Magne(50.0, 3.5, 30.0, 15.0, 50.0), // Cobre
                new Cond_Magne(30.0, 4.5, 35.0, 18.0, 55.0)  // Hierro
            };

            Glaciales = new List<Cond_Magne>
            {
                new Cond_Magne(150.0, 2.5, 15.0, 10.0, 25.0), // Cobre
                new Cond_Magne(100.0, 3.5, 18.0, 12.0, 35.0)  // Hierro
            };

            //POTENCIAL HIDROTERMAL
            Andosoles = new List<Pot_Hidro>
            {
                new Pot_Hidro(6.1, 200.0, 45.0, 30.0, 65.0), // Cobre
                new Pot_Hidro(6.4, 220.0, 40.0, 35.0, 70.0), // Oro
                new Pot_Hidro(5.6, 210.0, 42.0, 32.0, 60.0), // Plata
                new Pot_Hidro(5.9, 230.0, 50.0, 28.0, 75.0)  // Tungsteno
            };

            Entisoles = new List<Pot_Hidro>
            {
                new Pot_Hidro(6.2, 120.0, 35.0, 30.0, 35.0), // Cobre
                new Pot_Hidro(6.8, 130.0, 30.0, 33.0, 40.0), // Oro
                new Pot_Hidro(6.5, 110.0, 32.0, 31.0, 38.0), // Plata
                new Pot_Hidro(6.0, 140.0, 40.0, 29.0, 42.0)  // Tungsteno
            };
        }
    }
}
