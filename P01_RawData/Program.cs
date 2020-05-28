namespace P01_RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RawData
    {
        public static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = parameters[0];

                int engineSpeed = int.Parse(parameters[1]);
                int enginePower = int.Parse(parameters[2]);
                Engine engine = new Engine(engineSpeed, enginePower);

                int cargoWeight = int.Parse(parameters[3]);
                string cargoType = parameters[4];
                Cargo cargo = new Cargo(cargoWeight, cargoType);
               
                double tire1Pressure = double.Parse(parameters[5]);
                int tire1age = int.Parse(parameters[6]);
                double tire2Pressure = double.Parse(parameters[7]);
                int tire2age = int.Parse(parameters[8]);
                double tire3Pressure = double.Parse(parameters[9]);
                int tire3age = int.Parse(parameters[10]);
                double tire4Pressure = double.Parse(parameters[11]);
                int tire4age = int.Parse(parameters[12]);
                Tire tire = new Tire(tire1Pressure, tire1age, tire2Pressure, tire2age, tire3Pressure, tire3age, tire4Pressure, tire4age);

                cars.Add(new Car(model, engine, cargo, tire));
            }

            string command = Console.ReadLine();
   
            Predicate<Car> filter;

            if (command == "fragile")
            {
                filter = x => x.Cargo.CargoType == "fragile" && x.Tire.Tires.Any(y => y.Key < 1);
            }

            else
            {
                filter = x => x.Cargo.CargoType == "flamable" && x.Engine.EnginePower > 250;
            }
        
            Console.WriteLine(string.Join(Environment.NewLine, cars.FindAll(filter).Select(x=>x.Model)));
        }
    }
}
