using Microsoft.AspNetCore.Http;

namespace OnlineShop.Product.Domain.Models
{
    public class PhotoUpdateModel
    {
        public int Id { get; set; }
        public IFormFile File { get; set; }
    }
}
