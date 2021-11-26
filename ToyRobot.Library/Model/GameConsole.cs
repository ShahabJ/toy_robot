using System;
using ToyRobot.Library.CustomException;
using ToyRobot.Library.Handler;
using ToyRobot.Library.Interface;

namespace ToyRobot.Library.Model
{
    public class GameConsole
    {
        private CommandsHandler commandsHandler;
        private GenericRobot genericRobot;
        private IInputData inputData;

        public GameConsole(GenericRobot genericRobot, IInputData inputData, CommandsHandler commandsHandler)
        {
            this.genericRobot = genericRobot;
            this.inputData = inputData;
            this.commandsHandler = commandsHandler;
        }

        public GenericRobot Play()
        {
            Console.WriteLine("======Start =====");

            // if has next, loop the commands 
            while (!IsEnd())
            {
                try
                {
                    Run();
                }
                catch (RobotException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine("======End=====");

            return genericRobot;
        }

        private bool IsEnd() => !inputData.HasNextCmd();

        private void Run()
        {
            // convert the command and then execute it
            var cmd = inputData.NextCmd();
            this.genericRobot = commandsHandler.ExecuteCommand(cmd, genericRobot);
        }
    }
}