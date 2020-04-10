using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TokenGenerator;
using Xunit;

namespace UnitTests
{
    public class ParametersTests
    {
        [Fact]
        public void Parameters_defaults_colour_to_white()
        {
            Colour expected = new Colour("#ffffff");
            Parameters parameters = new Parameters();
            Assert.Equal(expected, parameters.Colour);
        }

        [Theory]
        [InlineData("#FFFFFF", "-c", "#ffffff")]
        [InlineData("#AAAAAA", "-c", "#aaAAaa")]
        public void Parameters_parses_colour(string expected, params string[] input)
        {
            Parameters p = new Parameters(input);

            var expectedColour = new Colour(expected);
            Assert.Equal(expectedColour, p.Colour);
        }

        [Theory]
        [InlineData("this is the text", "-c", "#FFffAA", "this is the text")]
        [InlineData("this is the text", "this is the text")]
        public void Parameters_parse_text(string expected, params string[] input)
        {
            Parameters p = new Parameters(input);
            Assert.Equal(expected, p.TokenText);
        }
    }
}