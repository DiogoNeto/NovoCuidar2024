using NovoCuidar2024.Migrations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace NovoCuidar2024.ViewModel
{
    public class FotoViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageContentType { get; set; }
    }
}
