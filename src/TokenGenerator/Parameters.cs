using System;
using System.Collections.Generic;
using System.Text;

namespace TokenGenerator
{
    public class Parameters
    {
        private enum States
        {
            TokenText,
            BackgroundColour
        }

        public Parameters(params string[] args)
        {
            States state = States.TokenText;
            List<string> tokenText = new List<string>();

            foreach (string arg in args)
            {
                if (arg == "-c")
                {
                    state = States.BackgroundColour;
                    continue;
                }

                switch (state)
                {
                    case States.BackgroundColour:
                        Colour = new Colour(arg);
                        state = States.TokenText;
                        continue;
                    case States.TokenText:
                        tokenText.Add(arg);
                        continue;
                }
            }

            TokenText = string.Join(" ", tokenText);
        }

        public Colour Colour { get; } = new Colour("#FFFFFF");
        public string TokenText { get; }
    }
}