namespace StudentSystem
{
    using System.Linq;

    public class CommandParser
    {
        public Command Parse(string command)
        {
            string[] Parts = command.Split();

            return new Command
            {
                Name = Parts[0],
                Arguments = Parts.Skip(1).ToArray()
            };

        }
    }
}
