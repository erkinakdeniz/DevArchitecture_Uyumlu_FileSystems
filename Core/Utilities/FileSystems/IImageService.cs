using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.FileSystems
{
    public interface IImageService
    {
        void AddImage(IFormFile image, string directory, bool isRandomName = false);
        void AddImages(IFormFile[] images, string directory, bool isRandomName = false);
        Task AddImageAsync(IFormFile image, string directory, bool isRandomName = false);
        Task AddImagesAsync(IFormFile[] images, string directory, bool isRandomName = false);
        void DeleteImage(string path);
        void DeleteImages(string[] path);
        void UpdateImage(IFormFile image, string directory);
        Task UpdateImagesAsync(IFormFile[] images, string directory);
        void ConvertToWebp(IFormFile image, string directory);
        void ImageResize(IFormFile image, string directory, int Width, int Height, string prefix);
        string ImageConvertToBase64(IFormFile image);
        void Base64ConvertToImage(string base64code, string directory);

    }
}
