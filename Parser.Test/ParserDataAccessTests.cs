using System;
using Franchise.Data.Data;
using Franchise.Data.Databases;
using Xunit;


namespace Franchise.Test
{
    public class ParserDataAccessTests
    {
        ParserDataAccess parser = new();

        [Fact]
        public void LineIsParsable()
        {
            var actual = parser.Parse("34.073638,-84.677017,Taco Bell Acwort...");

            Assert.NotNull(actual);

        }

        [Fact]
        public void NotParsableReturnsNull()
        {
            var actual = parser.Parse("34.073638,-84.677017");

            Assert.Null(actual);
        }


        [Theory]
        [InlineData("34.073638,-84.677017,Taco Bell Acwort...", -84.677017)]
        public void ParsesLongitude(string line, double expected)
        {
            var actual = parser.Parse(line).GeoPoint.Longitude;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("34.073638,-84.677017,Taco Bell Acwort...", 34.073638)]
        public void ParsesLatitude(string line, double expected)
        {
            var actual = parser.Parse(line).GeoPoint.Latitude;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("34.073638,-84.677017,Taco Bell Acwort...", "Taco Bell Acwort...")]
        public void ShouldParseName(string line, string expected)
        {
            var actual = parser.Parse(line).Name;

            Assert.Equal(expected, actual);
        }



    }
}
