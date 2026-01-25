using Microsoft.AspNetCore.Http;

namespace FN.Application.Contract.Models
{
    public class UploadModel
    {
        public IFormFile File { get; set; }
    }
}
