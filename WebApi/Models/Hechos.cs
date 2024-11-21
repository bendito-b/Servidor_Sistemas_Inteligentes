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
                { "Plomo", new Act_Geome(2000.0, 2.6, 350.0, 2.0, 300.0) },
                { "Zinc", new Act_Geome(2200.0, 2.7, 400.0, 2.2, 350.0) },
                { "Tungsteno", new Act_Geome(2400.0, 2.9, 500.0, 2.3, 400.0) },
                { "Carbón", new Act_Geome(1500.0, 2.3, 250.0, 1.5, 200.0) }
            };

            // ACTIVIDAD GEOMECÁNICA: Diccionario para Tipo de Suelo Vertisoles
            Vertisoles = new Dictionary<string, Act_Geome>
            {
                { "Plomo", new Act_Geome(3000.0, 3.1, 250.0, 2.5, 450.0) },
                { "Zinc", new Act_Geome(2800.0, 3.2, 300.0, 2.3, 400.0) },
                { "Tungsteno", new Act_Geome(3500.0, 3.4, 350.0, 2.8, 500.0) },
                { "Carbón", new Act_Geome(2200.0, 2.7, 150.0, 1.8, 300.0) }
            };

            // COMPOSICIÓN GEOQUÍMICA: Diccionario para Tipo de Suelo Residuales    
            Residuales = new Dictionary<string, Comp_Geoq>
            {
                { "Estaño", new Comp_Geoq(30.0, 12.0, 5.5, 1.2, 50.0) },
                { "Tungsteno", new Comp_Geoq(40.0, 15.0, 5.2, 1.5, 60.0) },
                { "Carbón", new Comp_Geoq(25.0, 10.0, 6.0, 0.8, 70.0) }
            };

            // OXISOLES: Diccionario para Tipo de Suelo Oxisoles    
            Oxisoles = new Dictionary<string, Comp_Geoq>
            {
                { "Estaño", new Comp_Geoq(80.0, 30.0, 4.8, 2.5, 85.0) },
                { "Tungsteno", new Comp_Geoq(100.0, 40.0, 4.5, 3.0, 80.0) },
                { "Carbón", new Comp_Geoq(60.0, 25.0, 5.0, 2.0, 75.0) }
            };

            // CONDUCTIVIDAD Y MAGNETISMO: Diccionario para Tipo de Suelo Lateritas    
            Lateritas = new Dictionary<string, Cond_Magne>
            {
                { "Cobre", new Cond_Magne(50.0, 3.5, 30.0, 15.0, 50.0) },
                { "Hierro", new Cond_Magne(30.0, 4.5, 35.0, 18.0, 55.0) }
            };

            // CONDUCTIVIDAD Y MAGNETISMO: Diccionario para Tipo de Suelo Glaciales    
            Glaciales = new Dictionary<string, Cond_Magne>
            {
                { "Cobre", new Cond_Magne(150.0, 2.5, 15.0, 10.0, 25.0) },
                { "Hierro", new Cond_Magne(100.0, 3.5, 18.0, 12.0, 35.0) }
            };

            // POTENCIAL HIDROTERMAL: Diccionario para Tipo de Suelo Andosoles    
            Andosoles = new Dictionary<string, Pot_Hidro>
            {
                { "Cobre", new Pot_Hidro(6.1, 200.0, 45.0, 30.0, 65.0) },
                { "Oro", new Pot_Hidro(6.4, 220.0, 40.0, 35.0, 70.0) },
                { "Plata", new Pot_Hidro(5.6, 210.0, 42.0, 32.0, 60.0) },
                { "Tungsteno", new Pot_Hidro(5.9, 230.0, 50.0, 28.0, 75.0) }
            };

            // POTENCIAL HIDROTERMAL: Diccionario para Tipo de Suelo Entisoles    
            Entisoles = new Dictionary<string, Pot_Hidro>
            {
                { "Cobre", new Pot_Hidro(6.2, 120.0, 35.0, 30.0, 35.0) },
                { "Oro", new Pot_Hidro(6.8, 130.0, 30.0, 33.0, 40.0) },
                { "Plata", new Pot_Hidro(6.5, 110.0, 32.0, 31.0, 38.0) },
                { "Tungsteno", new Pot_Hidro(6.0, 140.0, 40.0, 29.0, 42.0) }
            };
        }
    }
}