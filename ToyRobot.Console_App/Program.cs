using System;
using System.IO;
using ToyRobot.Library.Commands;
using ToyRobot.Library.Handler;
using ToyRobot.Library.Interface;
using ToyRobot.Library.Model;
using ToyRobot.Library.Service;

namespace ToyRobot.Console_App
{
    class Program
    {
        static void Main(string[] args)
        {
            if(!IsInputValid(args)){return;}

            GenericTable table = new GameTable();

            //inject the table to the robot brain
            GenericRobot robot = new GameRobot(table);

            IInputData inputData = new InputDataFromFile(args[0]);

            //register the valid command
            CommandsHandler commandsHandler = new CommandsHandler();
            commandsHandler.Register(new LeftCommand());
            commandsHandler.Register(new RightCommand());
            commandsHandler.Register(new MoveCommand());
            commandsHandler.Register(new PlaceCommand());
            commandsHandler.Register(new ReportCommand());

            // Robot play
            GameConsole gameConsole = new GameConsole(robot, inputData, commandsHandler);
            gameConsole.Play();
        }

        public const string VALID_EXTENSION = ".txt";
        public static bool IsInputValid(string[] args)
        {
            if(args.Length == 0 )
            {
                Console.WriteLine($"Please specify the file location.");
                return false;
            }
            var path = args[0];
            System.Console.WriteLine(Path.GetExtension(path));
            if(!Path.GetExtension(path).Equals(VALID_EXTENSION,StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("The file extension should be txt");
                return false;
            }

            if(!File.Exists(path))
            {
                Console.WriteLine($"The file does not exist.");
                return false;
            }

            return true;
        }
    }
}
