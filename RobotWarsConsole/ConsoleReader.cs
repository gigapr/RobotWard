using System;

namespace RobotWarsConsole
{
    public class ConsoleReader : IConsoleReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}