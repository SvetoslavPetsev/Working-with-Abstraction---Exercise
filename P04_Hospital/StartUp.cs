namespace P04_Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<Department> departments = new List<Department>();
            List<Doctor> doctors = new List<Doctor>();

            string data;
            while ((data = Console.ReadLine()) != "Output")
            {
                CreateDataForDepartments(data, departments);
                CreateDataForDoctors(data, doctors);
            }
            while ((data = Console.ReadLine()) != "End")
            {
                GetResult(data, departments, doctors);
            }
        }
        public static void CreateDataForDepartments(string data, List<Department> departments)
        {
            string[] info = data.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string departamentName = info[0];
            string patientName = info[3];

            if (!departments.Any(x => x.DepartmentName == departamentName))
            {
                Department newDepartment = new Department(departamentName);
                newDepartment.AddData(patientName);
                departments.Add(newDepartment);
            }
            else
            {
                Department currDepartment = departments.Find(x => x.DepartmentName == departamentName);

                if (currDepartment.HaveDepartmentCapacity())
                {
                    currDepartment.AddData(patientName);
                }
            }
        }
        public static void CreateDataForDoctors(string data, List<Doctor> doctors)
        {
            string[] info = data.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string patientName = info[3];
            string doctorName = $"{ info[1] } { info[2] }";

            if (!doctors.Any(x => x.Name == doctorName))
            {
                Doctor newDoctor = new Doctor(doctorName);
                newDoctor.PatientsList.Add(patientName);
                doctors.Add(newDoctor);
            }
            else
            {
                Doctor curr = doctors.FirstOrDefault(x => x.Name == doctorName);
                curr.PatientsList.Add(patientName);
            }
        }
        public static void GetResult(string command, List<Department> departments, List<Doctor> doctors)
        {
            string[] info = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (info.Length == 1)
            {
                string departmentName = info[0];
                List<string> patients = new List<string>();
                Department currDepartment = departments.Find(x => x.DepartmentName == departmentName);
                {
                    patients = currDepartment.GetPatients();
                }
                Print(patients);
            }
            else
            {
                int roomNumber = -1;
                if (int.TryParse(info[1], out roomNumber))
                {
                    string departmentName = info[0];
                    Department currDepartment = departments.Find(x => x.DepartmentName == departmentName);
                    List<string> patients = currDepartment.GetPatientsFromRoom(roomNumber);
                    Print(OrderAlphabetical(patients));
                }
                else
                {
                    string doctorName = $"{info[0]} {info[1]}";
                    List<string> patients = new List<string>();
                    foreach (var doctor in doctors.Where(x => x.Name == doctorName))
                    {
                        patients.AddRange(doctor.PatientsList);
                    }
                    Print(OrderAlphabetical(patients));
                }
            }
        }
        public static List<string> OrderAlphabetical(List<string> patients)
        {
            return patients = patients.OrderBy(x => x).ToList();
        }
        public static void Print(List<string> patients)
        {
            foreach (var patient in patients)
            {
                Console.WriteLine(patient);
            }
        }
    }
}
