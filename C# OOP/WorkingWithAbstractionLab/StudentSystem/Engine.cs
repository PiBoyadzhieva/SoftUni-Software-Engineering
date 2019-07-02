namespace StudentSystem
{
    using System;

    public class Engine
    {
        private CommandParser commandParser;
        private StudentSystem studentSystem;

        private Func<string> readInput;
        public Engine(CommandParser commandParser, StudentSystem studentSystem, Func<string> readInput)
        {
            this.commandParser = commandParser;
            this.studentSystem = studentSystem;
            this.readInput = readInput;
        }
        public void Run()
        {
            while (true)
            {
                Command command = commandParser.Parse(this.readInput());

                if (command.Name == "Create")
                {
                    string name = command.Arguments[0];
                    int age = int.Parse(command.Arguments[1]);
                    double grade = double.Parse(command.Arguments[2]);

                    studentSystem.Add(name, age, grade);
                }

                else if (command.Name == "Show")
                {
                    string name = command.Arguments[0];

                    Student student = studentSystem.Get(name);

                    Console.WriteLine(student);
                }

                else if (command.Name == "Exit")
                {
                    break;
                }
            }

        }
    }
}
