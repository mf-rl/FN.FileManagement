using System;
using SixLabors.ImageSharp;
using System.IO;

namespace FN.Functions
{
    public static class Generic
    {
        public static string ConvertSize(string fileName)
        {
            string[] sizes = { "B", "Kb", "Mb", "Gb", "Tb" };
            double len = new FileInfo(fileName).Length;
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }
            string result = string.Format("{0:0.##} {1}", len, sizes[order]);
            return result;
        }
        public static string SaveImageToFile(Image image, string uploadPath)
        {
            string detPath = GetNewFilePath(uploadPath);
            image.Save(detPath);
            image.Dispose();
            return detPath;
        }
        public static string GetNewFilePath(string rootPath, bool fullPath = true)
        {
            return Path.Combine(
                fullPath ? rootPath : string.Empty,
                string.Concat(Guid.NewGuid().ToString(), ".jpg")
            );
        }
    }
}
