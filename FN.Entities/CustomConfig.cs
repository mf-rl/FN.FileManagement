namespace FN.Entities
{
    public class CustomConfig
    {
        public bool UploadToDatabase { get; set; }
        public bool UploadToFileSystem { get; set; }
        public string UploadPath { get; set; }
        public double WidthPercent { get; set; }
        public double HeightPercent { get; set; }
        public int AllowedSize { get; set; }
        public string UploadUri { get; set; }
        public bool UseInMemoryDatabase { get; set; }
    }
}
