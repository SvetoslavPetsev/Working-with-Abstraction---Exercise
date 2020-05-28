using System.Collections.Generic;

namespace P04_Hospital
{
    public class Room
    {
        private int roomCapacity = 3;
        public Room()
        {
            this.Patients = new List<Patient>();
        }
        public List<Patient> Patients { get; private set; }

        public bool RoomHaveCapacity()
        {
            return this.roomCapacity > 0;
        }
        public void AddPatient(string name)
        {
            this.Patients.Add(new Patient(name));
            this.roomCapacity--;
        }
    }
}
