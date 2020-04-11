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
            BackgroundColour,
            Relationship
        }

        public Parameters(params string[] args)
        {
            States state = States.TokenText;
            List<string> tokenText = new List<string>();

            foreach (string arg in args)
            {
                switch (arg)
                {
                    case "-c":
                        state = States.BackgroundColour;
                        continue;
                    case "-r":
                        state = States.Relationship;
                        continue;
                }

                switch (state)
                {
                    case States.BackgroundColour:
                        Colour = new Colour(arg);
                        state = States.TokenText;
                        continue;
                    case States.Relationship:
                        switch (arg)
                        {
                            case "friendly":
                                Colour = new Colour("#00ff00");
                                break;
                            case "enemy":
                                Colour = new Colour("#ff0000");
                                break;
                            case "neutral":
                                Colour = new Colour("#aaaaaa");
                                break;
                        }
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