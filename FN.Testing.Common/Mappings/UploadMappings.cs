using FN.Testing.Business.Contract.Entities;
using FN.Testing.DataLayer.Contract.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FN.Testing.Common.Mappings
{
    public static class UploadMappings
    {
        public static UploadedEntity ToUploadedEntity(this Upload source)
        {
            if (source == null)
                return null;
            return new UploadedEntity
            {
                Id = source.Id,
                FileName = source.FileName,
                Extension = source.Extension,
                UploadDate = source.UploadDate
            };
        }

        public static IEnumerable<UploadedEntity> ToUploadedEntities(
            this IEnumerable<Upload> source)
        {
            return source?.Select(e => e.ToUploadedEntity());
        }
    }
}
