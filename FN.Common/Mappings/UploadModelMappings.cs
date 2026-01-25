using FN.Application.Contract.Models;
using FN.Business.Contract.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FN.Common.Mappings
{
    public static class UploadModelMappings
    {
        public static UploadEntity ToUploadEntity(this UploadModel source)
        {
            if (source == null) return null;
            return new UploadEntity
            {
                File = source.File
            };
        }
    }
}
