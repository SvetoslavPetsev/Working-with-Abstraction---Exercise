namespace P04_Hospital
{
    using System.Collections.Generic;
    public class Doctor
    {
        public Doctor(string name)
        {
            this.Name = name;
            this.PatientsList = new List<string>();
        }
        public string Name { get; private set; }
        public List<string> PatientsList { get; private set; }
    }
}
