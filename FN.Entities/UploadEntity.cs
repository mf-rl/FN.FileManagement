using FN.Entities.Abstractions;
using Microsoft.AspNetCore.Http;

namespace FN.Entities
{
    public class UploadEntity : IEntity
    {
        public int Id { get; set; }
        public IFormFile File { get; set; }
    }
}
