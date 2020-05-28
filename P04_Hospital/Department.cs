namespace P04_Hospital
{
    using System.Collections.Generic;
    using System.Linq;

    public class Department
    {
        private int departmentCapacity = 20;
        public Department(string departmentName)
        {
            this.DepartmentName = departmentName;
            this.Rooms = new List<Room>();
            this.Rooms.Add(new Room());
        }

        public string DepartmentName { get; set; }
        public List<Room> Rooms { get; private set; }

        public bool HaveDepartmentCapacity()
        {
            return this.departmentCapacity > 0;
        }
        public void AddData(string patient)
        {
            if (this.Rooms.Any(x => x.RoomHaveCapacity()))
            {
                this.Rooms.Find(x => x.RoomHaveCapacity()).AddPatient(patient);
            }
            else
            {
                this.Rooms.Add(new Room());
                this.Rooms.Find(x => x.RoomHaveCapacity()).AddPatient(patient);
                this.departmentCapacity--;
            }
        }
        public List<string> GetPatients()
        {
            List<string> patients = new List<string>();
            foreach (var room in this.Rooms)
            {
                foreach (var patient in room.Patients)
                {
                    patients.Add(patient.Name);
                }
            }
            return patients;
        }
        public List<string> GetPatientsFromRoom(int roomNumber)
        {
            List<string> patients = new List<string>();
            var patientsInRoom = this.Rooms[roomNumber - 1].Patients;

            foreach (var patient in patientsInRoom)
            {
                patients.Add(patient.Name);
            }

            return patients;
        }
    }
}
