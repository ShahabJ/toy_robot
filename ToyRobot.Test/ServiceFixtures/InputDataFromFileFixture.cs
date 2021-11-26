using FluentAssertions;
using ToyRobot.Library.Interface;
using ToyRobot.Library.Service;
using Xunit;

namespace ToyRobot.Test.ServiceFixtures
{
    public class InputDataFromFileFixture
    {
        private IInputData input ; 
        private readonly string path ="./ServiceFixtures/Data/SampleFile.txt";

        public InputDataFromFileFixture()
        {
            input = new InputDataFromFile(path);
        }

        [Fact]
        public void TestInputDataGetALlLinesCorrectly()
        {
            var actualResult = new string[4];
            int i=0;
            while (input.HasNextCmd())
            {
                 actualResult[i++] = input.NextCmd();
            }
            actualResult[0].Should().Be("This is Header");
            actualResult[1].Should().Be("This is Line 1");
            actualResult[2].Should().Be("This is Line 2");
            actualResult[3].Should().Be("This is Footer");
        }
    }
}