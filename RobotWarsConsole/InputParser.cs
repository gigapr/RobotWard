using System;
using System.Linq;
using RobotWars.Domain;

namespace RobotWarsConsole
{
    public class InputParser
    {
        public static Coordinate ParseArenaSize(string input)
        {
            var coordinates = input.Trim().Split(' ');

            int latitude;
            int longitude;

            if (coordinates.Length == 2 && Int32.TryParse(coordinates[0], out latitude) && Int32.TryParse(coordinates[1], out longitude))
            {
                return new Coordinate(latitude, longitude);
            }

            throw new ArgumentException();
        }

        public static IRobot ParseRobotInput(string input)
        {
            var position = input.Trim().Split(' ');

            int latitude;
            int longitude;

            if (position.Length == 3 && Int32.TryParse(position[0], out latitude) && Int32.TryParse(position[1], out longitude))
            {
                return new Robot(position[2].ToOrientation(), latitude, longitude);
            }

            throw new ArgumentException();
        }

        public static Move[] ParseMoves(string input)
        {
            return input.ToCharArray().Select(m => m.ToMove()).ToArray();
        }        
    }
}