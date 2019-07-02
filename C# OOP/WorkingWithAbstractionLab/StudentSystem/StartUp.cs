namespace StudentSystem
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            CommandParser commandParser = new CommandParser();
            StudentSystem studentSystem = new StudentSystem();

            Engine engine = new Engine(commandParser, studentSystem, Console.ReadLine);

            engine.Run();
        }
    }
}
