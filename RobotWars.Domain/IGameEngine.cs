namespace RobotWars.Domain
{
    public interface IGameEngine
    {
        Arena Arena { get; }

        void AddRobotToArea(IRobot robot);
        void MoveRobot(IRobot robot, params Move[] moves);
    }
}