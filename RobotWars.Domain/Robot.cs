using System;

namespace RobotWars.Domain
{
    public class Robot : IRobot
    {
        public Guid Id { get; private set; }
        public Coordinate Coordinate { get; set; }
        public Orientation Orientation { get; set; }

        public Robot(Orientation orientation, int latitude, int longitude)
        {
            Id = Guid.NewGuid();
            Coordinate = new Coordinate(latitude, longitude);
            Orientation = orientation;
        }

        public override string ToString()
        {
            return string.Format("Id: {0}, Position: {1}, Orientation: {2}", Id, Coordinate, Orientation);
        }
    }
}