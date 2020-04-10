using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestPlatform.Common;
using TokenGenerator;
using Xunit;

namespace UnitTests
{
    public class ColourTests
    {
        [Fact]
        public void Colour_starts_with_hash()
        {
            Assert.Throws<Colour.InvalidColourException>(() => new Colour("123456"));
        }

        [Theory]
        [InlineData("#f")]
        [InlineData("#fffffff")]
        [InlineData("#")]
        [InlineData("#1")]
        [InlineData("#gggggg")]
        public void Colour_has_6_hex_values(string input)
        {
            Assert.Throws<Colour.InvalidColourException>(() => new Colour(input));
        }

        [Theory]
        [InlineData("#ffffff", 255, 255, 255)]
        [InlineData("#000000", 0, 0, 0)]
        [InlineData("#ff0000", 255, 0, 0)]
        [InlineData("#00FF00", 0, 255, 0)]
        [InlineData("#0000Ff", 0, 0, 255)]
        public void Colour_created_from_hex(string input, int red, int green, int blue)
        {
            // Given a hex string

            // When I create the colour
            Colour colour = new Colour(input);

            // Then the rgb values are correct
            Assert.Equal(red, colour.Red);
            Assert.Equal(green, colour.Green);
            Assert.Equal(blue, colour.Blue);
        }

        [Fact]
        public void Equality()
        {
            Colour left = new Colour("#FFFFFF");
            Colour right = new Colour("#FFFFFF");

            Assert.Equal(left, right);
            Assert.Equal(right, left);
            Assert.True(left == right);
            Assert.True(right == left);
            Assert.False(left != right);
            Assert.False(right != left);
            Assert.True(left.Equals(right));
            Assert.True(right.Equals(left));
        }

        [Fact]
        public void Inequality()
        {
            Colour left = new Colour("#FFFFFF");
            Colour right = new Colour("#FFFFFA");

            Assert.NotEqual(left, right);
            Assert.NotEqual(right, left);
            Assert.False(left == right);
            Assert.False(right == left);
            Assert.True(left != right);
            Assert.True(right != left);
            Assert.False(left.Equals(right));
            Assert.False(right.Equals(left));
        }

        [Theory]
        [InlineData("#ffffff", "#FFFFFF")]
        public void Colour_ToString(string input, string expected)
        {
            Colour colour = new Colour(input);
            Assert.Equal(expected, colour.ToString());
        }
    }
}
