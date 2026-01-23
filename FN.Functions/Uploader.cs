using FN.Test.Functions;
using FN.Common.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using System;
using System.IO;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace FN.Functions
{
    public static class Uploader
    {
        public static async Task<byte[]> DownloadFile(string fileName)
        {
            return await File.ReadAllBytesAsync(GetFullUploadFile(fileName));
        }
        private static string GetFullUploadFile(string fileName)
        {
            return Path.Combine(StaticConfigs.GetConfig("UploadPath"), fileName);
        }
        public static string GetContentType(string filePath)
        {
            filePath = GetFullUploadFile(filePath);
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(filePath, out var contentType))
            {
                contentType = "application/octet-stream";
            }
            return contentType;
        }
        public static bool DeleteFile(string filePath)
        {
            try
            {
                filePath = GetFullUploadFile(filePath);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                return true;
            }
            catch
            {
                return false;
            }            
        }
        public static string UploadFile(IFormFile file)
        {
            double widthPercent =
                Convert.ToDouble(StaticConfigs.GetConfig("WidthPercent")) / 100;

            double heightPercent =
                Convert.ToDouble(StaticConfigs.GetConfig("HeightPercent")) / 100;

            int allowedSize =
                Convert.ToInt32(StaticConfigs.GetConfig("AllowedSize"));

            string fileExtension =
                Path.GetExtension(file.FileName).ToLowerInvariant();

            string uploadDir = StaticConfigs.GetConfig("UploadPath");
            Directory.CreateDirectory(uploadDir);

            string targetPath = Path.Combine(
                uploadDir,
                $"{Guid.NewGuid()}{fileExtension}"
            );

            // Save original upload
            using (var stream = new FileStream(targetPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            switch (fileExtension)
            {
                case ".jpg":
                case ".jpeg":
                case ".png":
                    {
                        using Image image = Image.Load(targetPath);

                        int newWidth = (int)(image.Width * widthPercent);
                        int newHeight = (int)(image.Height * heightPercent);

                        image.Mutate(x => x.Resize(newWidth, newHeight));

                        // Replace original
                        File.Delete(targetPath);

                        string resizedPath =
                            new Generic().SaveImageToFile(image, uploadDir);

                        // Enforce max file size
                        targetPath =
                            new ImageResizer().ScaleImage(
                                resizedPath,
                                allowedSize,
                                deleteSrcFile: true
                            );
                        break;
                    }
            }
            return Path.GetFileName(targetPath);
        }
    }
}
