//using FN.Testing.Business.Contract.Entities;
//using FN.Testing.DataLayer.Contract.Tables;
//using System.Collections.Generic;
//using System.Linq;

//namespace FN.Testing.Business.Mapping
//{
//    public static class UploadMappings
//    {
//        public static UploadedEntity ToUploadedEntity(this Upload source)
//        {
//            if (source == null) return null;

//            return new UploadedEntity
//            {
//                Id = source.Id,
//                FileName = source.FileName,
//                Extension = source.Extension,
//                UploadDate = source.UploadDate
//            };
//        }

//        public static IEnumerable<UploadedEntity> ToUploadedEntities(
//            this IEnumerable<Upload> source)
//        {
//            return source?.Select(ToUploadedEntity);
//        }

//        public static Upload ToUpload(this UploadedEntity source)
//        {
//            if (source == null) return null;

//            return new Upload
//            {
//                Id = source.Id,
//                FileName = source.FileName,
//                Extension = source.Extension,
//                UploadDate = source.UploadDate
//            };
//        }
//        public static Upload ToUpload(this UploadEntity source)
//        {
//            if (source == null) return null;

//            return new Upload
//            {
//                Id = source.Id
//            };
//        }
//    }
//}
