using RobotWars.Domain.Exceptions;

namespace RobotWars.Domain
{
    public class Arena 
    {
        public IRobot[,] Grid { get; private set; }

        public Arena(int latitude, int longitude) 
        {
            if(latitude < 0 || longitude < 0)
                throw new InvalidArenaSizeException("Arena Latitude and Longitude should be at least 1");

            Grid = new IRobot[latitude + 1, longitude + 1];
        }

        public bool PositionIsOccupied(Coordinate coordinate)
        {
            return  Grid[coordinate.Latitude, coordinate.Longitude] != null;
        }

        public void SetRobotPosition(IRobot robot, int latitude, int longitude)
        {
            Grid[robot.Coordinate.Latitude, robot.Coordinate.Longitude] = null;
            Grid[latitude, longitude] = robot;

            robot.Coordinate = new Coordinate(latitude, longitude);
        }

        public bool IsWithinBoundaries(int latitude, int longitude)
        {
            return (latitude >= 0 && latitude < Grid.GetLength(0)) && 
                   (longitude >= 0 && longitude < Grid.GetLength(1));
        }
    }
}