using System.IO;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.Primitives;

namespace Shared.Helpers
{
    public static class ImageHelper
    {
        public static Stream AddTextToImage(Stream imageStream, params (string text, (int x, int y) position)[] texts)
        {
            var memoryStream = new MemoryStream();

            var image = Image.Load(imageStream);

            image
                .Clone(img =>
                {
                    foreach (var (text, (x, y)) in texts)
                    {
                        img.DrawText(text, SystemFonts.CreateFont("Verdana", 24), Rgba32.OrangeRed, new PointF(x, y));
                    }
                })
                .SaveAsPng(memoryStream);

            memoryStream.Position = 0;

            return memoryStream;
        }
    }
}
