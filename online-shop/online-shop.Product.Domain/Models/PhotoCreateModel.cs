using Microsoft.AspNetCore.Http;

namespace OnlineShop.Product.Domain.Models
{
    public class PhotoCreateModel
    {
        public IFormFile File { get; set; }
    }
}
