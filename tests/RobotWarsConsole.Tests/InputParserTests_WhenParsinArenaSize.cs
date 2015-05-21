using System;
using NUnit.Framework;

namespace RobotWarsConsole.Tests
{
    [TestFixture]
    public class InputParserTests_WhenParsinArenaSize
    {
        [TestCase("3 3", 3, 3)]
        [TestCase("1 3", 1, 3)]
        [TestCase("1 5", 1, 5)]
        [TestCase("6 6", 6, 6)]
        [TestCase("6 6 ", 6, 6)]
        [TestCase(" 6 6", 6, 6)]
        public void should_be_able_to_create_an_arena(string input, int expectedLatitude, int expectedLongitude)
        {
            var coordinate = InputParser.ParseArenaSize(input);

            Assert.That(coordinate.Latitude, Is.EqualTo(expectedLatitude));
            Assert.That(coordinate.Longitude, Is.EqualTo(expectedLongitude));
        }

        [TestCase("a 0")]
        [TestCase("13")]
        [TestCase("1 A")]
        [TestCase("A a")]
        public void should_throw_an_exception_when_arena_size_input_invalid(string input)
        {
            Assert.Throws<ArgumentException>(() => InputParser.ParseArenaSize(input));
        }
    }
}
