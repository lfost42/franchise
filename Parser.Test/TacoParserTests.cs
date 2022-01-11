using System;
using Xunit;

namespace Parser.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void LineIsParsable()
        {
            var tacoParser = new TacoParser();

            var actual = tacoParser.Parse("34.073638,-84.677017,Taco Bell Acwort...");

            Assert.NotNull(actual);

        }

        [Fact]
        public void NotParsableReturnsNull()
        {
            var tacoParser = new TacoParser();

            var actual = tacoParser.Parse("34.073638,-84.677017");

            Assert.Null(actual);
        }


        [Theory]
        [InlineData("34.073638,-84.677017,Taco Bell Acwort...", -84.677017)]
        public void ParsesLongitude(string line, double expected)
        {
            var tacoParserInstance = new TacoParser();

            var actual = tacoParserInstance.Parse(line).GeoPoint.Longitude;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("34.073638,-84.677017,Taco Bell Acwort...", 34.073638)]
        public void ParsesLatitude(string line, double expected)
        {
            var tacoParserInstance = new TacoParser();

            var actual = tacoParserInstance.Parse(line).GeoPoint.Latitude;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("34.073638,-84.677017,Taco Bell Acwort...", "Taco Bell Acwort...")]
        public void ShouldParseName(string line, string expected)
        {
            var tacoParserInstance = new TacoParser();

            var actual = tacoParserInstance.Parse(line).Name;

            Assert.Equal(expected, actual);
        }



    }
}
