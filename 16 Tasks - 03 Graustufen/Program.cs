using SkiaSharp;

namespace dotNet_16_Tasks_03_Graustufen
{
    internal class Program
    {
        static DirectoryInfo picturesDir = new DirectoryInfo(@"..\..\..\Bilder");
        static DirectoryInfo greyPicturesDir = new DirectoryInfo(@"..\..\..\BilderGrau");
        static void Main(string[] args)
        {

            FileSystemWatcher fileSystemWatcher = new FileSystemWatcher(picturesDir.FullName);
            fileSystemWatcher.Created += (sender, e) =>
            {
                Task.Run(() =>
                {
                    Task.Delay(2000).Wait();
                    Console.WriteLine(e.FullPath);
                    Console.WriteLine(@$"{greyPicturesDir.FullName}\{e.Name}");
                    ColorToGray(SKBitmap.Decode(e.FullPath), @$"{greyPicturesDir.FullName}\{e.Name}");
                });
            };

            fileSystemWatcher.EnableRaisingEvents = true;

            Console.ReadKey();
        }

        static void ColorToGray(SKBitmap image, string grayFilename)
        {
            for (int x = 0; x < image.Width; x++)
            {
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write($"{x + 1}/{image.Width}");
                for (int y = 0; y < image.Height; y++)
                {
                    SKColor color = image.GetPixel(x, y);
                    byte gray = (byte)(0.2126f * color.Red + 0.7152f * color.Green + 0.0722f *
                    color.Blue);
                    SKColor sKColor = new SKColor(gray, gray, gray, color.Alpha);
                    image.SetPixel(x, y, sKColor);
                }
            }
            Console.WriteLine(" done");
            try
            {
                using (FileStream grayFileStream = File.Create(grayFilename))
                {
                    image.Encode(grayFileStream, SKEncodedImageFormat.Jpeg, 100);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            image.Dispose();
        }
    }
}
