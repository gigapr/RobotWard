using NUnit.Framework;
using RobotWars.Domain.Exceptions;

namespace RobotWars.Domain.Tests
{
    [TestFixture]
    public class GameEngineTests
    {
        private IGameEngine _gameEngine;

        [SetUp]
        public void SetUp()
        {
            _gameEngine = new GameEngine(5, 5);
        }

        [Test]
        public void Should_be_able_to_add_a_robot_to_the_arena()
        {
            const int latitude = 3;
            const int longitude = 1;
            const Orientation orientation = Orientation.E;

            var robot = new Robot(orientation, latitude, longitude);

            _gameEngine.AddRobotToArea(robot);

            var result = _gameEngine.Arena.Grid[latitude, longitude];

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(robot.Id));
            Assert.That(result.Orientation, Is.EqualTo(orientation));
        }

        [Test]
        public void Should_throw_an_exception_when_position_in_arena_is_already_occupied_by_another_robot()
        {
            const int latitude = 3;
            const int longitude = 1;
            const Orientation orientation = Orientation.E;

            var robot = new Robot(orientation, latitude, longitude);

            _gameEngine.Arena.Grid[latitude, longitude] = robot;

            Assert.Throws<RobotMoveException>(() => _gameEngine.AddRobotToArea(robot));
        }

        [TestCase(1, 2, Orientation.W, 0, 2)]
        [TestCase(1, 1, Orientation.S, 1, 0)]
        [TestCase(1, 1, Orientation.E, 2, 1)]
        [TestCase(1, 1, Orientation.N, 1, 2)]
        public void Should_be_able_to_move_a_robot_forward(int inititalLatitude, int inititalLongitude, Orientation orientation, int expectedLatitude, int expectedLongitude)
        {
            var robot = new Robot(orientation, inititalLatitude, inititalLongitude);
            _gameEngine.Arena.Grid[inititalLatitude, inititalLongitude] = robot;

            _gameEngine.MoveRobot(robot, Move.Forward);

            Assert.That(_gameEngine.Arena.Grid[expectedLatitude, expectedLongitude], Is.EqualTo(robot));
            Assert.That(_gameEngine.Arena.Grid[inititalLatitude, inititalLongitude], Is.EqualTo(null));

            Assert.That(robot.Coordinate.Latitude, Is.EqualTo(expectedLatitude));
            Assert.That(robot.Coordinate.Longitude, Is.EqualTo(expectedLongitude));
        }

        [TestCase(4, 4, Orientation.N)]
        [TestCase(4, 4, Orientation.E)]
        [TestCase(4, 1, Orientation.E)]
        public void Should_throw_an_excpetion_when_position_is_outside_arena_boundaries(int originalLatitude, int originalLongitude, Orientation inititalOrientation)
        {
            var robot = new Robot(inititalOrientation, originalLatitude, originalLongitude);

            _gameEngine.Arena.Grid[originalLatitude, originalLongitude] = robot;
            
            Assert.Throws<RobotMoveException>(() => _gameEngine.MoveRobot(robot, Move.Forward, Move.Forward));
        }
    }
}