using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital
{
    class Engine
    {
        private Dictionary<string, List<string>> doctors;
        private Dictionary<string, List<List<string>>> departments;
        public Engine()
        {
            this.doctors = new Dictionary<string, List<string>>();
            this.departments = new Dictionary<string, List<List<string>>>();
        }

        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "Output")
            {
                string[] inputArgs = command.Split();

                var department = inputArgs[0];
                var firstName = inputArgs[1];
                var secondName = inputArgs[2];
                var patient = inputArgs[3];

                var fullName = firstName + secondName;

                AddDoctor(fullName);

                AddDepartment(department);

                bool isFree = departments[department]
                    .SelectMany(x => x)
                    .Count() < 60;

                if (isFree)
                {
                    doctors[fullName].Add(patient);

                    AddPatientToRoom(department, patient);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] args = command.Split();

                if (args.Length == 1)
                {
                    string departmentName = args[0];

                    PrintPatiensInDepartment(departmentName);
                }
                else if (args.Length == 2)
                {
                    bool isRoom = int.TryParse(args[1], out int room);

                    if(isRoom)
                    {
                        string departmentName = args[0];

                        PrintAllPatiensInRoom(departmentName, room);
                    }
                    else
                    {
                        string fullName = args[0] + args[1];

                        PrintAllPatientsDoctor(fullName);
                    }
                }

                command = Console.ReadLine();
            }

        }

        private void PrintAllPatientsDoctor(string fullName)
        {
            var allPatientsOfDoctor = doctors[fullName]
                .OrderBy(x => x).
                ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, allPatientsOfDoctor));
        }

        private void PrintAllPatiensInRoom(string departmentName, int room)
        {
            var allPatientInRoom = departments[departmentName][room - 1]
                .OrderBy(x => x)
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, allPatientInRoom));
        }

        private void PrintPatiensInDepartment(string departmentName)
        {
            var allPatientInDepartment = departments[departmentName]
                .Where(x => x.Count > 0)
                .SelectMany(x => x)
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, allPatientInDepartment));
        }

        private void AddPatientToRoom(string department, string patient)
        {
            int room = 0;

            for (int currentRoom = 0; currentRoom < departments[department].Count; currentRoom++)
            {
                if (departments[department][currentRoom].Count < 3)
                {
                    room = currentRoom;
                    break;
                }
            }
            //int targetRoom = departments[department].SelectMany(x => x).Count();
            departments[department][room].Add(patient);
        }

        private void AddDepartment(string departament)
        {
            if (!departments.ContainsKey(departament))
            {
                departments[departament] = new List<List<string>>();

                for (int room = 0; room < 20; room++)
                {
                    departments[departament].Add(new List<string>());
                }
            }
        }

        private void AddDoctor(string fullName)
        {
            if (!doctors.ContainsKey(fullName))
            {
                doctors[fullName] = new List<string>();
            }
        }
    }
}
