using System;

namespace RobotWars.Domain.Exceptions
{
    public class InvalidArenaSizeException : Exception
    {
        public InvalidArenaSizeException(string message) : base(message)
        {
        }
    }
}