using System;
using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;

namespace FN.Test.Functions
{
    public class ImageResizer
    {
        private int allowedFileSizeInByte;
        private string sourcePath;
        private string destinationPath;

        public ImageResizer(int allowedSize, string sourcePath, string destinationPath)
        {
            allowedFileSizeInByte = allowedSize;
            this.sourcePath = sourcePath;
            this.destinationPath = destinationPath;
        }

        public ImageResizer()
        {
        }

        public void ScaleImage()
        {
            using var fs = File.OpenRead(sourcePath);

            IImageFormat format = Image.DetectFormat(fs);
            fs.Position = 0;

            using Image image = Image.Load(fs);
            using MemoryStream ms = new MemoryStream();

            SaveTemporary(image, ms, format, 90);

            while (ms.Length > allowedFileSizeInByte || ms.Length < 0.9 * allowedFileSizeInByte)
            {
                double scale = Math.Sqrt((double)allowedFileSizeInByte / ms.Length);

                int newWidth = Math.Max(1, (int)(image.Width * scale));
                int newHeight = Math.Max(1, (int)(image.Height * scale));

                image.Mutate(x => x.Resize(newWidth, newHeight));

                ms.SetLength(0);
                SaveTemporary(image, ms, format, 85);
            }

            SaveImageToFile(ms);
        }

        private void SaveImageToFile(MemoryStream ms)
        {
            File.WriteAllBytes(destinationPath, ms.ToArray());
        }

        private void SaveTemporary(Image image, MemoryStream ms, IImageFormat format, int quality)
        {
            if (format.Name.Equals("JPEG", StringComparison.OrdinalIgnoreCase))
            {
                image.Save(ms, new JpegEncoder { Quality = quality });
            }
            else
            {
                image.Save(ms, format);
            }
        }

        public Image ScaleImage(Image image, double scale)
        {
            int newWidth = Math.Max(1, (int)(image.Width * scale));
            int newHeight = Math.Max(1, (int)(image.Height * scale));

            return image.Clone(x => x.Resize(newWidth, newHeight));
        }

        public Image ResizeImage(Image srcImage, int newWidth, int newHeight)
        {
            return srcImage.Clone(x => x.Resize(newWidth, newHeight));
        }

        public string ScaleImage(string sourcePath, int allowedSize, bool deleteSrcFile = false)
        {
            string destPath = new Generic().GetNewFilePath(Path.GetDirectoryName(sourcePath));

            ImageResizer resizer = new ImageResizer(allowedSize, sourcePath, destPath);
            resizer.ScaleImage();

            if (deleteSrcFile)
                File.Delete(sourcePath);

            return destPath;
        }
    }
}
