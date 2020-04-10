using System;

namespace TokenGenerator
{
    public class Parameters
    {
        public Parameters(params string[] args)
        {
            int colourIndex = Array.IndexOf(args, "-c");
            if (colourIndex > -1)
            {
                Colour = new Colour(args[colourIndex + 1]);
                Range textRange = Range.StartAt(colourIndex + 2);
                TokenText = string.Join("\n", args[textRange]);
                return;
            }

            TokenText = string.Join("\n", args);
        }

        public Colour Colour { get; } = new Colour("#FFFFFF");
        public string TokenText { get; }
    }
}