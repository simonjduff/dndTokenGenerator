using System;
using System.Text.RegularExpressions;

namespace TokenGenerator
{
    public struct Colour
    {
        private static readonly Regex RgbRegex = new Regex("^#(?<red>[0-9a-fA-F]{2})(?<green>[0-9a-fA-F]{2})(?<blue>[0-9a-fA-F]{2})$");
        private const string Hex = "0123456789ABCDEF";
        private const int Exponent = 16;
        public Colour(string input)
        {
            var match = RgbRegex.Match(input);
            if (!match.Success)
            {
                throw new InvalidColourException();
            }

            Red = HexToInt(match.Groups["red"].Value);
            Green = HexToInt(match.Groups["green"].Value);
            Blue = HexToInt(match.Groups["blue"].Value);
        }

        private static int HexToInt(string hex)
        {
            if (hex.Length != 2)
            {
                throw new InvalidOperationException("Must have 2 chars of hex");
            }

            hex = hex.ToUpper();

            return Hex.IndexOf(hex[0]) * Exponent + Hex.IndexOf(hex[1]);
        }

        public class InvalidColourException : Exception { }

        public int Blue { get; }
        public int Green { get; }
        public int Red { get; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            Colour other = (Colour) obj;
            return Red == other.Red
                   && Blue == other.Blue
                   && Green == other.Green;
        }

        public bool Equals(Colour other)
        {
            return Blue == other.Blue && Green == other.Green && Red == other.Red;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Blue;
                hashCode = (hashCode * 397) ^ Green;
                hashCode = (hashCode * 397) ^ Red;
                return hashCode;
            }
        }

        public static bool operator ==(Colour left, Colour right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Colour left, Colour right)
        {
            return !(left == right);
        }

        public override string ToString()
            => $"#{Red:X}{Green:X}{Blue:X}";
    }
}