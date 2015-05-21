using RobotWars.Domain.Exceptions;

namespace RobotWars.Domain
{
    public class GameEngine : IGameEngine
    {
        public Arena Arena { get; set; }

        public GameEngine(int latitude, int longitude)
        {
            Arena = new Arena(latitude, longitude);
        }

        public void AddRobotToArea(IRobot robot)
        {
            if (Arena.PositionIsOccupied(robot.Coordinate))
                throw new RobotMoveException(string.Format("Position at {0} {1} is already occupied by Robot '{2}.", robot.Coordinate.Latitude, robot.Coordinate.Longitude, Arena.Grid[robot.Coordinate.Latitude, robot.Coordinate.Longitude].Id));

            Move(robot, robot.Coordinate.Latitude, robot.Coordinate.Longitude);                
        }

        public void MoveRobot(IRobot robot, params Move[] moves)
        {
            foreach (var move in moves)
            {
                Move(robot, move);
            }
        }

        private void Move(IRobot robot, Move move)
        {
            switch (move)
            {
                case Domain.Move.SpinLeft:
                    robot.Orientation = (Orientation) (((int) robot.Orientation + 3)%4);
                    break;
                case Domain.Move.SpinRight:
                    robot.Orientation = (Orientation) (((int) robot.Orientation + 1)%4);
                    break;
                case Domain.Move.Forward:
                    UpdatePosition(robot);
                    break;
            }
        }

        private void UpdatePosition(IRobot robot)
        {
            switch (robot.Orientation)
            {
                case Orientation.N:
                    Move(robot, robot.Coordinate.Latitude, robot.Coordinate.Longitude + 1);
                    break;
                case Orientation.E:
                    Move(robot, robot.Coordinate.Latitude + 1, robot.Coordinate.Longitude);
                    break;
                case Orientation.S:
                    Move(robot, robot.Coordinate.Latitude, robot.Coordinate.Longitude - 1);
                    break;
                case Orientation.W:
                    Move(robot, robot.Coordinate.Latitude - 1, robot.Coordinate.Longitude);
                    break;
            }
        }

        private void Move(IRobot robot, int latitude, int longitude)
        {
            if (Arena.IsWithinBoundaries(latitude, longitude))
                Arena.SetRobotPosition(robot, latitude, longitude);                
            else
                throw new RobotMoveException(string.Format("New position at {0} {1} is outside arena.", latitude, longitude));
        }
    }
}