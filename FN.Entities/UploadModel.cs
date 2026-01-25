using Microsoft.AspNetCore.Http;

namespace FN.Entities
{
    public class UploadModel
    {
        public IFormFile File { get; set; }
    }
}
