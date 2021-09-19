using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Ex9Backend.Logic
{
    public class ImageLogic : IImageLogic
    {
        private readonly IWebHostEnvironment hostingEnvironment;
        private string defaultBaseUrl = "http://localhost:5000";

        public ImageLogic(IWebHostEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }

        public async Task<string> SaveImage(IFormFile image)
        {

            string uniqueFileName = GetUniqueFileName(image.FileName);
            string imageSavePath = Path.Combine(hostingEnvironment.WebRootPath, "images", uniqueFileName);
            //await image.CopyToAsync(new FileStream(imageSavePath, FileMode.Create, FileAccess.Write));

            using (var image2 = Image.FromStream(image.OpenReadStream()))
            using (var newImage = ScaleImage(image2, 300, 300))
            {
                newImage.Save(imageSavePath, ImageFormat.Jpeg);
            }


            return $"{defaultBaseUrl}/images/{uniqueFileName}";
        }

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString()
                      + Path.GetExtension(fileName);
        }

        private  static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth /image.Width;
            var ratioY = (double)maxHeight /image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(newImage))
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);

            return newImage;
        }
    }
}
