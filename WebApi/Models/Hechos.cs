namespace WebApi.Models
{
    public class Hechos
    {
        // Diccionarios para cada tipo de suelo, donde la clave es el nombre del mineral
        public Dictionary<string, Act_Geome> Sedimentarios { get; private set; }
        public Dictionary<string, Act_Geome> Vertisoles { get; private set; }
        public Dictionary<string, Comp_Geoq> Residuales { get; private set; }
        public Dictionary<string, Comp_Geoq> Oxisoles { get; private set; }
        public Dictionary<string, Cond_Magne> Lateritas { get; private set; }
        public Dictionary<string, Cond_Magne> Glaciales { get; private set; }
        public Dictionary<string, Pot_Hidro> Andosoles { get; private set; }
        public Dictionary<string, Pot_Hidro> Entisoles { get; private set; }

        // Constructor para inicializar los diccionarios
        public Hechos()
        {
            // ACTIVIDAD GEOMECÁNICA: Diccionario para Tipo de Suelo Sedimentarios    
            Sedimentarios = new Dictionary<string, Act_Geome>
            {
                { "Plomo", new Act_Geome(150.0, 2.5, 400.0, 2.0, 350.0) }, // MPa , g/cm³, m
                { "Zinc", new Act_Geome(200.0, 2.7, 500.0, 2.3, 450.0) },
                { "Tungsteno", new Act_Geome(250.0, 3.0, 600.0, 2.5, 600.0) },
                { "Carbón", new Act_Geome(100.0, 2.0, 200.0, 1.3, 200.0) }
            };

            // ACTIVIDAD GEOMECÁNICA: Diccionario para Tipo de Suelo Vertisoles
            Vertisoles = new Dictionary<string, Act_Geome>
            {
                { "Plomo", new Act_Geome(250.0, 2.9, 300.0, 2.5, 450.0) },
                { "Zinc", new Act_Geome(300.0, 3.1, 400.0, 2.8, 550.0) },
                { "Tungsteno", new Act_Geome(350.0, 3.4, 600.0, 3.0, 700.0) },
                { "Carbón", new Act_Geome(150.0, 2.4, 150.0, 1.5, 250.0) }
            };


            // COMPOSICIÓN GEOQUÍMICA: Diccionario para Tipo de Suelo Residuales
            Residuales = new Dictionary<string, Comp_Geoq>
            {
                { "Estaño", new Comp_Geoq(100.0, 25.0, 5.5, 2.5, 80.0) }, // ppm, %, mS/cm
                { "Tungsteno", new Comp_Geoq(200.0, 20.0, 5.0, 3.5, 70.0) },
                { "Carbón", new Comp_Geoq(30.0, 8.0, 6.5, 1.8, 50.0) },
                { "Cuarzo", new Comp_Geoq(10.0, 2.0, 7.5, 1.0, 40.0) }
            };

            // COMPOSICIÓN GEOQUÍMICA: Diccionario para Tipo de Suelo Oxisoles
            Oxisoles = new Dictionary<string, Comp_Geoq>
            {
                { "Estaño", new Comp_Geoq(150.0, 30.0, 5.0, 3.0, 90.0) },
                { "Tungsteno", new Comp_Geoq(300.0, 25.0, 4.8, 4.0, 85.0) },
                { "Carbón", new Comp_Geoq(20.0, 5.0, 6.0, 1.5, 60.0) },
                { "Cuarzo", new Comp_Geoq(5.0, 1.0, 7.0, 0.8, 30.0) }
            };

            // CONDUCTIVIDAD Y MAGNETISMO: Diccionario para Tipo de Suelo Lateritas    
            Lateritas = new Dictionary<string, Cond_Magne>
            {
                { "Cobre", new Cond_Magne(1.72, 1.2, 25, 1.5, 7) }, // Ω·m, A/m, %
                { "Hierro", new Cond_Magne(1.33, 2.7, 17, 3.0, 35) },
                { "Cobalto", new Cond_Magne(0.60, 2.0, 20, 2.5, 12) },
                { "Níquel", new Cond_Magne(0.97, 1.5, 30, 2.0, 15) }
            };

            // CONDUCTIVIDAD Y MAGNETISMO: Diccionario para Tipo de Suelo Glaciales    
            Glaciales = new Dictionary<string, Cond_Magne>
            {
                { "Cobre", new Cond_Magne(2.14, 1.0, 15, 1.0, 5) },
                { "Hierro", new Cond_Magne(1.86, 2.3, 12, 2.5, 40) },
                { "Cobalto", new Cond_Magne(0.95, 1.7, 19, 3.7, 14) },
                { "Níquel", new Cond_Magne(1.30, 1.2, 24, 1.8, 20) }
            };

            // POTENCIAL HIDROTERMAL: Diccionario para Tipo de Suelo Andosoles    
            Andosoles = new Dictionary<string, Pot_Hidro>
            {
                { "Cobre", new Pot_Hidro(5.0, 250.0, 15.0, 200.0, 30.0) }, // °C, %, m³
                { "Oro", new Pot_Hidro(6.5, 400.0, 25.0, 400.0, 60.0) },
                { "Plata", new Pot_Hidro(5.8, 300.0, 18.0, 250.0, 40.0) },
                { "Tungsteno", new Pot_Hidro(4.8, 230.0, 22.0, 280.0, 50.0) }
            };

            // POTENCIAL HIDROTERMAL: Diccionario para Tipo de Suelo Entisoles    
            Entisoles = new Dictionary<string, Pot_Hidro>
            {
                { "Cobre", new Pot_Hidro(6.0, 270.0, 10.0, 150.0, 25.0) },
                { "Oro", new Pot_Hidro(7.2, 420.0, 20.0, 350.0, 55.0) },
                { "Plata", new Pot_Hidro(6.3, 320.0, 12.0, 180.0, 35.0) },
                { "Tungsteno", new Pot_Hidro(5.5, 260.0, 14.0, 220.0, 45.0) }
            };
        }
    }
}