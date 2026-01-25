using FN.Testing.Business.Contract.Entities;
using FN.Testing.DataLayer.Contract.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace FN.Testing.Common.Mappings
{
    public static class UploadEntityMappings
    {
        public static Upload ToUpload(this UploadEntity source)
        {
            if (source == null)
                return null;
            return new Upload
            {
                Id = source.Id,
                Extension = System.IO.Path.GetExtension(source.File?.FileName),
                FileName = source.File?.FileName,
                UploadDate = DateTimeOffset.UtcNow
            };
        }
    }
}
