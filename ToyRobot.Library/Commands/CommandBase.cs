using System.Text.RegularExpressions;
using ToyRobot.Library.Model;

namespace ToyRobot.Library.Commands
{
    public abstract class CommandBase
    {
        public abstract string Name { get; }
        public abstract string Regex_Pattern { get; }

        public abstract GenericRobot Execute(GenericRobot genericRobot);
        public virtual bool IsValidCommand(string cmd) => Regex.Match(cmd, Regex_Pattern, RegexOptions.IgnoreCase).Success;

    }
}