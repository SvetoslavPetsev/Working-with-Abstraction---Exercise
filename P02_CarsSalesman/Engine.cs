
namespace P02_CarsSalesman
{

    using System.Text;

    public class Engine
    {
        private const string offset = "  ";
        private readonly int power;
        private readonly int displacement;
        public string Efficiency { get; private set; }

        public Engine(string model, int power)
        {
            this.Model = model;
            this.power = power;
            this.displacement = -1;
            this.Efficiency = "n/a";
        }

        public Engine(string model, int power, int displacement) : this(model, power)
        {
            this.displacement = displacement;
            this.Efficiency = "n/a";
        }

        public Engine(string model, int power, string efficiency) : this(model, power)
        {
            this.displacement = -1;
            this.Efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement, string efficiency) : this(model, power)
        {
            this.displacement = displacement;
            this.Efficiency = efficiency;
        }
        public string Model { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}{1}:\n", offset, this.Model);
            sb.AppendFormat("{0}{0}Power: {1}\n", offset, this.power);
            sb.AppendFormat("{0}{0}Displacement: {1}\n", offset, this.displacement == -1 ? "n/a" : this.displacement.ToString());
            sb.AppendFormat("{0}{0}Efficiency: {1}\n", offset, this.Efficiency);

            return sb.ToString();
        }
    }
}
