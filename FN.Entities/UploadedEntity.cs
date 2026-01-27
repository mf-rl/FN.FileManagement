using System;

namespace FN.Entities
{
    public class UploadedEntity
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public DateTimeOffset UploadDate { get; set; }
        public string Extension { get; set; }
    }
}
