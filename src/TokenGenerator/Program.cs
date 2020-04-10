using System;
using System.Collections.Generic;
using System.Linq;

namespace TokenGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Argument count {args.Length}");
            Console.WriteLine(string.Join(" ", args.Select(a => $"[{a}]")));

            Parameters parameters = new Parameters(args);
            Console.WriteLine($"Detected colour {parameters.Colour}");
        }
    }

    public class Parameters
    {
        public Parameters(params string[] args)
        {
            int colourIndex = Array.IndexOf(args, "-c");
            if (colourIndex > -1)
            {
                Colour = new Colour(args[colourIndex + 1]);
                Range textRange = Range.StartAt(colourIndex + 2);
                TokenText = string.Join(" ", args[textRange]);
                return;
            }

            TokenText = string.Join(" ", args);
        }

        public Colour Colour { get; } = new Colour("#FFFFFF");
        public string TokenText { get; }
    }
}
