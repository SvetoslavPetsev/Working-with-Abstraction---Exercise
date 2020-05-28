namespace P02_CarsSalesman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CarSalesman
    {
        public static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Engine> engines = new List<Engine>();

            int engineCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < engineCount; i++)
            {
                string[] parameters = Console
                    .ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                Engine engine = GetEngineFromParam(parameters);
                AddEngineToList(engines, engine);
            }
            int carCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < carCount; i++)
            {
                string[] parameters = Console
                    .ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                Car car = GetCarFromParam(engines, parameters);
                AddCarToList(cars, car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
        public static void AddCarToList(List<Car> carList, Car car)
        {
            carList.Add(car);
        }
        public static Car GetCarFromParam(List<Engine> engines, string[] parameters)
        {
            string model = parameters[0];
            string engineModel = parameters[1];
            Engine engine = engines.FirstOrDefault(x => x.Model == engineModel);

            int weight = -1;

            if (parameters.Length == 3 && int.TryParse(parameters[2], out weight))
            {
                return new Car(model, engine, weight);
            }
            else if (parameters.Length == 3)
            {
                string color = parameters[2];
                return new Car(model, engine, color);
            }
            else if (parameters.Length == 4)
            {
                string color = parameters[3];
                return new Car(model, engine, int.Parse(parameters[2]), color);
            }
            else
            {
                return new Car(model, engine);
            }
        }
        public static void AddEngineToList(List<Engine> engineList, Engine engine)
        {
            engineList.Add(engine);
        }
        public static Engine GetEngineFromParam(string[] parameters)
        {
            string model = parameters[0];
            int power = int.Parse(parameters[1]);
            int displacement = -1;

            if (parameters.Length == 3 && int.TryParse(parameters[2], out displacement))
            {
                return new Engine(model, power, displacement);
            }
            else if (parameters.Length == 3)
            {
                string efficiency = parameters[2];
                return new Engine(model, power, efficiency);
            }
            else if (parameters.Length == 4)
            {
                string efficiency = parameters[3];
                return new Engine(model, power, int.Parse(parameters[2]), efficiency);
            }
            else
            {
                return new Engine(model, power);
            }
        }
    }
}
