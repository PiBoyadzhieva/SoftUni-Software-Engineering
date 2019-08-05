using System;

namespace MXGP
{
    using Models.Motorcycles;
    using MXGP.Core;

    public class StartUp
    {
        public static void Main()
        {
            //TODO Add IEngine
            //Motorcycle varche = new PowerMotorcycle("12214235", 75);
            //Console.WriteLine(varche.HorsePower);

            Engine engine = new Engine();

            engine.Run();
        }
    }
}
