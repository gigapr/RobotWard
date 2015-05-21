using System;

namespace RobotWars.Domain.Exceptions
{
    public class RobotMoveException : Exception
    {
        public RobotMoveException(string message) : base(message)
        {
        }
    }
}