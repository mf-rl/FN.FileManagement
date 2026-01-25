using System.Collections.Generic;
using System.Linq;
using FN.Testing.Application.Contract.Models;
using FN.Testing.Business.Contract.Entities;

namespace FN.Testing.Business.Mappings
{
    public static class UploadedEntityMappings
    {
        public static UploadedModel ToUploadedModel(this UploadedEntity source)
        {
            if (source == null)
                return null;

            return new UploadedModel
            {
                Id = source.Id,
                FileName = source.FileName,
                Extension = source.Extension,
                UploadDate = source.UploadDate
            };
        }

        public static IEnumerable<UploadedModel> ToUploadedModels(
            this IEnumerable<UploadedEntity> source)
        {
            return source?.Select(e => e.ToUploadedModel());
        }
    }
}
