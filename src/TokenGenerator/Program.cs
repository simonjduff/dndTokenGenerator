using System;
using System.IO;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.Primitives;

namespace TokenGenerator
{
    class Program
    {
        private const int Width = 150;
        private const int Height = 150;

        static int Main(string[] args)
        {
            Parameters parameters = new Parameters(args);
            Console.WriteLine($"Token text {parameters.TokenText}");
            Console.WriteLine($"Detected colour {parameters.Colour}");

            Image image = new Image<Argb32>(Configuration.Default, Width, Height);
            Font font = SystemFonts.CreateFont("arial", 48);
            var colour = parameters.Colour;
            var rendererOptions = new RendererOptions(font);
            var textSize = TextMeasurer.Measure(parameters.TokenText, rendererOptions);

            if (textSize.Width > Width || textSize.Height > Height)
            {
                Console.WriteLine("Text is too big");
                return -1;
            }

            Console.WriteLine($"Text size {textSize}");
            var backgroundColour = new Color(new Argb32(colour.Red, colour.Green, colour.Blue));

            var textImage = image.Clone(c =>
            {
                c
                .BackgroundColor(backgroundColour)
                .DrawText(
                    parameters.TokenText, font, new Color(new Argb32(0,0,0)),
                    new PointF(Width / 2 - textSize.Width / 2,
                        Height / 2 - textSize.Height / 2));
            });
            var writer = File.OpenWrite("token.png");
            textImage.SaveAsPng(writer);

            return 0;
        }
    }
}
