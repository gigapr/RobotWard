using System;
using RobotWars.Domain;

namespace RobotWarsConsole
{
    internal static class GameExtensions
    {
        public static Move ToMove(this char move)
        {
            switch (Char.ToUpper(move))
            {
                case 'L':
                    return Move.SpinLeft;
                case 'M':
                    return Move.Forward;
                case 'R':
                    return Move.SpinRight;
                default:
                    throw new ArgumentException(string.Format("Unable to map '{0}' to a valid robot move", move));
            }
        }

        public static Orientation ToOrientation(this string data)
        {
            switch (data.ToUpper())
            {
                case "N":
                    return Orientation.N;
                case "E":
                    return Orientation.E;
                case "S":
                    return Orientation.S;
                case "W":
                    return Orientation.W;
                default:
                    throw new ArgumentException(string.Format("'{0}' doesn't contain a valid robot orientation.", data));
            }
        }
    }
}