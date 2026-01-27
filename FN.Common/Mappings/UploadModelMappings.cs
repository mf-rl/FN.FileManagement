using FN.Entities;

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
