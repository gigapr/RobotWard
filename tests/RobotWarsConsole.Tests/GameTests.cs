using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using RobotWars.Domain;

namespace RobotWarsConsole.Tests
{
    [TestFixture]
    public class GameTests
    {
        private Game _game;
        private Mock<IConsoleReader> _consoleReader;

        [SetUp]
        public void SetUp()
        {
            _consoleReader = new Mock<IConsoleReader>();

            _game = new Game(_consoleReader.Object);
        }

        [TestCase("1 2 N", "LMLMLMLMM", "1 3 N")]
        [TestCase("3 3 e", "MMRMMRMRRM", "5 1 E")]
        public void Should_get_robot_position_after_moves(string robotPosition, string moves, string expected)
        {
            var readLines = new Queue<string>();
            readLines.Enqueue("5 5");
            readLines.Enqueue(robotPosition);
            readLines.Enqueue(moves);

            _consoleReader.Setup(reader => reader.ReadLine()).Returns(readLines.Dequeue);

            var result = _game.Start();

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(Orientation.N, "L", Orientation.W)]
        [TestCase(Orientation.N, "R", Orientation.E)]
        [TestCase(Orientation.E, "l", Orientation.N)]
        [TestCase(Orientation.E, "r", Orientation.S)]
        [TestCase(Orientation.S, "L", Orientation.E)]
        [TestCase(Orientation.S, "R", Orientation.W)]
        [TestCase(Orientation.W, "l", Orientation.S)]
        [TestCase(Orientation.W, "R", Orientation.N)]
        public void Should_be_able_to_spin_a_robot_in_the_arena(Orientation inititalOrientation, string moves, Orientation expected)
        {
            const string initialPosition = "3 1";

            var readLines = new Queue<string>();
            readLines.Enqueue("5 5");
            readLines.Enqueue(string.Format("{0} {1}",initialPosition, inititalOrientation));
            readLines.Enqueue(moves);

            _consoleReader.Setup(reader => reader.ReadLine()).Returns(readLines.Dequeue);

            var result = _game.Start();

            Assert.That(result, Is.EqualTo(string.Format("{0} {1}", initialPosition, expected)));
        }
    }
}