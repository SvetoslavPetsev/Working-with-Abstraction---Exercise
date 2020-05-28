namespace P04_Hospital
{
    public class Patient
    {
        public Patient(string patient)
        {
            this.Name = patient;
        }
        public string Name { get; private set; }
    }
}
