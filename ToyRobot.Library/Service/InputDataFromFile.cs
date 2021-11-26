
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ToyRobot.Library.Interface;

namespace ToyRobot.Library.Service
{
    public class InputDataFromFile : IInputData
    {
        private List<string> commands ;
        private List<string>.Enumerator itr;

        public InputDataFromFile(string path)
        {
            commands =File.ReadAllLines(path).ToList();
            itr = commands.GetEnumerator();
        }
        public bool HasNextCmd() => itr.MoveNext();

        public string NextCmd()
        {
            return itr.Current;
        }
    }
}