using System;

namespace RobotWarsConsole
{
    public class Program
    {
        private static void Main()
        {
            var resut = new Game(new ConsoleReader()).Start();

            Console.WriteLine(resut);
            Console.ReadKey();
        }
    }
}
