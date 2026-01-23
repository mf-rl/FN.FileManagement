using FN.Entities;
using FN.DataLayer.Contract.Tables;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FN.Common.Mappings
{
    public static class UploadEntityMappings
    {
        public static async Task<Upload> ToNewUploadAsync(
            this UploadEntity source,
            CancellationToken cancellationToken = default)
        {
            if (source?.File == null)
                return null;

            return new Upload
            {
                Id = source.Id,
                FileName = Guid.NewGuid().ToString(),
                Extension = Path.GetExtension(source.File.FileName),
                UploadDate = DateTimeOffset.UtcNow,
                FileContent = await ReadFileAsync(source.File, cancellationToken)
            };
        }

        private static async Task<byte[]> ReadFileAsync(
            IFormFile content,
            CancellationToken cancellationToken)
        {
            using var ms = new MemoryStream();
            await content.CopyToAsync(ms, cancellationToken);
            return ms.ToArray();
        }
    }
}
