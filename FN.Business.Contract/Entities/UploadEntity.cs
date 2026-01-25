using Microsoft.AspNetCore.Http;
using System;

namespace FN.Business.Contract.Entities
{
    public class UploadEntity : IEntity
    {
        public int Id { get; set; }
        public IFormFile File { get; set; }
    }
}
