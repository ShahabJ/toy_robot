using System;
using System.Collections.Generic;
using ToyRobot.Library.Commands;
using ToyRobot.Library.CustomException;
using ToyRobot.Library.Model;

namespace ToyRobot.Library.Handler
{
    public class CommandsHandler
    {
        private const string SPLIT_REGEX = " ";
        private const int CMD_INDEX = 0;
        private const string SKIP_MSG = "Skip command {0} because the game not started until a PLACE cmd found";

        private Dictionary<string, CommandBase> registeredCommands = new Dictionary<string, CommandBase>();

        public void Register(CommandBase command) => registeredCommands.Add(command.Name, command);
        public void Remove(string commandName) => registeredCommands.Remove(commandName);

        public GenericRobot ExecuteCommand(string cmd, GenericRobot genericRobot)
        {
            Console.WriteLine("Detected commands: " + cmd);

            var elements = cmd.Split(SPLIT_REGEX);

            // execute if commands registered, execute it, otherwise throw an exception
            CommandBase command;
            if (!registeredCommands.TryGetValue(elements[CMD_INDEX], out command) || !command.IsValidCommand(cmd))
            {
                throw new RobotException(CustomExceptionMessageConstants.INVALID_CMD);
            }

            // if it is Place command or Place command is executed, the above command will be executed , otherwise skip the command
            if (!(command is PlaceCommand) && !genericRobot.IsPlacedOnTable())
            {
                Console.WriteLine(SKIP_MSG, cmd);
                return genericRobot;
            }

            return command.Execute(genericRobot);
        }
    }
}