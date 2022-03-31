using System.Drawing;
using System.IO;
using ImageProcessor;

namespace OnlineShop.Product.Domain.Utils
{
    public class ImageHelper
    {
        public byte[] ResizeImage(byte[] image, Size size)
        {
            using (var output = new MemoryStream())
            {
                using (var imageFactory = new ImageFactory(preserveExifData: true))
                {
                    imageFactory.Load(image)
                                .Resize(size)
                                .Save(output);
                    return output.ToArray();
                }
            }
        }
    }
}
