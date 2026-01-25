using System;

namespace FN.DataLayer.Contract.Tables
{
    public class Upload
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public DateTimeOffset UploadDate { get; set; }
        public string Extension { get; set; }
    }
}
