using System;
using System.Linq;
using System.Reflection;

using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    class CommandInterpreter : ICommandInterpreter
    {
        private const string commandPostfix = "Command";
        public string Read(string args)
        {
            string[] commandTokens = args
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string commandName = commandTokens[0] + commandPostfix;

            string[] commandArgs = commandTokens
                .Skip(1)
                .ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();

            Type[] types = assembly.GetTypes();

            Type typeToCreate = types.FirstOrDefault(t => t.Name == commandName);

            if(typeToCreate == null)
            {
                throw new InvalidOperationException("Invalid command type!");
            }

            Object instance = Activator.CreateInstance(typeToCreate);

            ICommand command = (ICommand)instance;

            string result = command.Execute(commandArgs);

            return result;
        }
    }
}
