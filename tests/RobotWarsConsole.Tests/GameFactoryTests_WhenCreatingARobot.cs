using System;
using NUnit.Framework;
using RobotWars.Domain;

namespace RobotWarsConsole.Tests
{
    [TestFixture]
    public class GameFactoryTests_WhenCreatingARobot
    {
        [TestCase("1 2 N", 1, 2, Orientation.N)]
        [TestCase("3 3 E", 3, 3, Orientation.E )]
        [TestCase("4 3 E", 4, 3, Orientation.E )]
        [TestCase("6 7 W", 6, 7, Orientation.W)]
        [TestCase("6 3 S", 6, 3, Orientation.S)]
        [TestCase("6 3 s", 6, 3, Orientation.S)]
        [TestCase("6 3 n ", 6, 3, Orientation.N)]
        [TestCase(" 6 3 n", 6, 3, Orientation.N)]
        public void Should_be_able_to_create_a_robot(string input, int expectedLatitude, int expectedLongitude, Orientation expectedOrientation)
        {
            var robot = InputParser.ParseRobotInput(input);

            Assert.That(robot.Orientation, Is.EqualTo(expectedOrientation));
            Assert.That(robot.Coordinate.Latitude, Is.EqualTo(expectedLatitude));
            Assert.That(robot.Coordinate.Longitude, Is.EqualTo(expectedLongitude));
        }

        [TestCase("1 2 0")]
        [TestCase("5 6 AE")]
        [TestCase("2 4 D")]
        [TestCase("A 2 E")]
        [TestCase("1 A E")]
        [TestCase("1E")]
        [TestCase("1 E")]
        public void should_throw_an_exception_when_arena_size_input_invalid(string input)
        {
            Assert.Throws<ArgumentException>(() => InputParser.ParseRobotInput(input));
        }
    }
}