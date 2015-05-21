using System;

namespace RobotWars.Domain
{
    public interface IRobot
    {
        Guid Id { get; }
        Coordinate Coordinate { get; set; }
        Orientation Orientation { get; set; }
    }
}