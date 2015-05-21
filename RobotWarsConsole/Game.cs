using RobotWars.Domain;

namespace RobotWarsConsole
{
    public class Game
    {
        private readonly IConsoleReader _consoleReader;

        public Game(IConsoleReader consoleReader)
        {
            _consoleReader = consoleReader;
        }

        public string Start()
        {
            var arenaSize = InputParser.ParseArenaSize(_consoleReader.ReadLine());
            var gameEngine = new GameEngine(arenaSize.Latitude, arenaSize.Longitude);

            while (true)
            {
                var robot = InputParser.ParseRobotInput(_consoleReader.ReadLine());

                gameEngine.AddRobotToArea(robot);
                gameEngine.MoveRobot(robot, InputParser.ParseMoves(_consoleReader.ReadLine()));

                return string.Format("{0} {1} {2}", robot.Coordinate.Latitude, robot.Coordinate.Longitude, robot.Orientation);
            }
        }
    }
}