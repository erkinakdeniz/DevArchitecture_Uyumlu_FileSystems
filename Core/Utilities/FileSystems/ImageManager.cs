using Microsoft.AspNetCore.Http;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.FileSystems
{
    public class ImageManager : CommonService, IImageService
    {
        public ImageManager()
        {

        }
        public void AddImage(IFormFile image, string directory, bool isRandomName = false)
        {

            string path = "";
            if (isRandomName)
            {
                path = directory + RandomName(image);
            }
            else
            {
                path = directory + image.FileName;
            }
            DirectoryControl(directory);
            this.Add(image, path);

        }
        public Task AddImageAsync(IFormFile image, string directory, bool isRandomName = false)
        {
            return Task.Run(() =>
            {

                string path = "";
                if (isRandomName)
                {
                    path = directory + RandomName(image);
                }
                else
                {
                    path = directory + image.FileName;
                }
                DirectoryControl(directory);
                this.AddAsync(image, path);

            });
        }

        public void AddImages(IFormFile[] images, string directory, bool isRandomName = false)
        {

            string path = "";
            DirectoryControl(directory);
            foreach (var item in images)
            {
                if (isRandomName)
                {
                    path = directory + RandomName(item);
                }
                else
                {
                    path = directory + item.FileName;
                }
                this.Add(item, path);
            }

        }

        public Task AddImagesAsync(IFormFile[] images, string directory, bool isRandomName = false)
        {
            return Task.Run(() => {
                string path = "";
                DirectoryControl(directory);
                foreach (var item in images)
                {
                    if (isRandomName)
                    {
                        path = directory + RandomName(item);
                    }
                    else
                    {
                        path = directory + item.FileName;
                    }
                    this.AddAsync(item, path);
                }
            });

        }

        public void DeleteImage(string path)
        {
            this.DeleteFile(path);

        }

        public void DeleteImages(string[] path)
        {
            this.DeleteFiles(path);
        }

        public void UpdateImage(IFormFile image, string directory)
        {

            string path = directory + image.FileName;
            DirectoryControl(directory);
            this.Add(image, path);

        }

        public Task UpdateImagesAsync(IFormFile[] images, string directory)
        {
            return Task.Run(() => {
                DirectoryControl(directory);
                foreach (var item in images)
                {
                    string path = directory + item.FileName;
                    this.AddAsync(item, path);
                }
            });


        }
        public void ConvertToWebp(IFormFile image, string directory)
        {
            string sourcepath, newPath;
            TempFile(image, directory, out sourcepath, out newPath, "webp");

            using (var stream = new FileStream(sourcepath, FileMode.Create))
            {
                image.CopyTo(stream);
            }

            // load the PNG file in an instance of Image
            using (var img = Aspose.Imaging.Image.Load(sourcepath))
            {
                // create an instance of WebpOptions
                var options = new Aspose.Imaging.ImageOptions.WebPOptions();
                DirectoryControl(directory);
                // save PNG as a WEBP
                img.Save(newPath, options);

            }

        }
        public void ImageResize(IFormFile image, string localSavePath, int Width, int Height, string prefix = "")
        {
            FileInfo fileInfo = new FileInfo(image.FileName);

            string sourcepath, newPath;
            TempFile(image, localSavePath, out sourcepath, out newPath, "jpg");

            Image imgBef = Image.FromStream(image.OpenReadStream(), true, true);
            Image _imgR = Resize(imgBef, Width, Height, true);
            //Save JPEG  
            SaveJpeg(newPath, _imgR);
        }

        public string ImageConvertToBase64(IFormFile image)
        {
            Image img = Image.FromStream(image.OpenReadStream());
            return GetImageBase64(ImageToByteArray(img));
        }
        public void Base64ConvertToImage(string base64code, string directory)
        {
            string path = $@"{directory}{RandomName("jpg")}";
            DirectoryControl(directory);
            SaveJpeg(path, Base64ToImageConverter(base64code));
        }
        private Image Base64ToImageConverter(string base64code)
        {
            StringBuilder sbText = new System.Text.StringBuilder(base64code, base64code.Length);
            sbText.Replace("\r\n", String.Empty); sbText.Replace(" ", String.Empty);
            Byte[] bitmapData = Convert.FromBase64String(sbText.ToString());
            System.IO.MemoryStream streamBitmap = new System.IO.MemoryStream(bitmapData);
            Bitmap bitImage = new Bitmap((Bitmap)Image.FromStream(streamBitmap));
            return bitImage;

        }
        private bool DirectoryControl(string path)
        {
            if (Directory.Exists(path))
            {
                return true;
            }
            else
            {
                Directory.CreateDirectory(path);
                return true;
            }
        }

        private static void TempFile(IFormFile image, string directory, out string sourcepath, out string newPath, string extension)
        {
            sourcepath = Path.GetTempFileName();
            FileInfo fileInfo = new FileInfo(image.FileName);
            newPath = $@"{directory}{fileInfo.Name.Split(".")[0]}.{extension}";
        }

        private string RandomName(IFormFile file)
        {
            var fileInfo = new FileInfo(file.FileName);
            return $@"{Guid.NewGuid()}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Year}{fileInfo.Extension}";
        }
        private string RandomName(string extension)
        {
            extension = "." + extension;
            return $@"{Guid.NewGuid()}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Year}{extension}";
        }

        private string FindImageDirectory(string path)
        {
            string[] filePathArray = path.Split(@"\");
            string fileDirectory = "";
            filePathArray[filePathArray.Length - 1] = "";
            foreach (var item in filePathArray)
            {
                if (item != "")
                    fileDirectory += item + @"\";
            }
            return fileDirectory;
        }

        private Image Resize(Image image, int Width, int maxHeight, bool onlyResizeIfWider)
        {
            if (onlyResizeIfWider && image.Width <= Width) Width = image.Width;

            var newHeight = image.Height * Width / image.Width;
            if (newHeight > maxHeight)
            {
                // Resize with height instead  
                Width = image.Width * maxHeight / image.Height;
                newHeight = maxHeight;
            }

            var res = new Bitmap(Width, newHeight);

            using (var graphic = Graphics.FromImage(res))
            {
                graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphic.SmoothingMode = SmoothingMode.HighQuality;
                graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphic.CompositingQuality = CompositingQuality.HighQuality;
                graphic.DrawImage(image, 0, 0, Width, newHeight);
            }

            return res;
        }

        private void SaveJpeg(string path, Image img)
        {
            var qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
            var jpegCodec = GetEncoderInfo("image/jpeg");

            var encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;
            img.Save(path, jpegCodec, encoderParams);

        }
        private ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            return ImageCodecInfo.GetImageEncoders().FirstOrDefault(t => t.MimeType == mimeType);
        }
        private byte[] ImageToByteArray(Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, ImageFormat.Gif);
            return ms.ToArray();
        }
        private string GetImageBase64(object img)
        {
            return "data:image/jpg;base64," + Convert.ToBase64String((byte[])img);
        }
        private Image Rotate(IFormFile img, RotateFlipType angle)
        {

            Bitmap resim = (Bitmap)Bitmap.FromStream(img.OpenReadStream());
            resim.RotateFlip(angle);
            return resim;

        }
        // CropImage metodunda x ve y koordinatlarına bakacak olursak bunların anlamı şu şekildedir:

        // x: Resmin yatay olarak x koordinatındaki yerini ifade eder.

        // y: Resmin dikey olarak y koordinatındaki yerini ifade eder.

        // x = 0; y = 0; olduğunda resmin sol en üst kısmından başlayarak kesme işlemini yapacaktır.
        private Image CropImage(Image image, int x, int y, int width, int height)
        {
            Rectangle rectDestination = new Rectangle(x, y, width, height);
            Bitmap bmp = new Bitmap(rectDestination.Width, rectDestination.Height);
            Graphics gr = Graphics.FromImage(bmp);
            gr.CompositingQuality = CompositingQuality.Default;
            gr.SmoothingMode = SmoothingMode.Default;
            gr.InterpolationMode = InterpolationMode.Bicubic;
            gr.PixelOffsetMode = PixelOffsetMode.Default;
            gr.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height), rectDestination, GraphicsUnit.Pixel);
            return bmp;
        }


    }
}
