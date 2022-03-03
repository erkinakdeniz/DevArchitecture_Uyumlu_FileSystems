using Business.Handlers.Image.Commands;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Handlers.Image.ValidationRules
{
   public class ImageValidatior
    {
        public class AddImageAsyncCommandValidatior : AbstractValidator<AddImageAsyncCommand>
        {
            public AddImageAsyncCommandValidatior()
            {
                RuleFor(x => x.Image).NotEmpty().WithMessage("Boş Dosya Gönderilemez!");
                RuleFor(x => x.Image).Must(ImageType).WithMessage("Seçtiğiniz Görselin Formatı Uygun Değildir!");
                
            }
            private bool ImageType(IFormFile image)
            {
                if (image == null)
                    return false;
                string[] imageTypes = new string[] {"image/jpeg",
                    "image/png",
                    "image/gif",
                    "image/webp",
                    "image/tiff",
                    "image/svg",
                    "image/bmp",
                    "image/psd",
                    "image/eps",
                    "image/pict"
                };
                foreach (var types in imageTypes)
                {
                    if (image.ContentType.Contains(types)) {
                        return true;
                    }

                }
                return false;
            }
        }
        public class AddImageCommandValidatior : AbstractValidator<AddImageCommand>
        {
            public AddImageCommandValidatior()
            {
                RuleFor(x => x.Image).NotEmpty().WithMessage("Boş Dosya Gönderilemez!");
                RuleFor(x => x.Image).Must(ImageType).WithMessage("Seçtiğiniz Görselin Formatı Uygun Değildir!");
            }
            private bool ImageType(IFormFile image)
            {
                if (image == null)
                    return false;
                string[] imageTypes = new string[] {"image/jpeg",
                    "image/png",
                    "image/gif",
                    "image/webp",
                    "image/tiff",
                    "image/svg",
                    "image/bmp",
                    "image/psd",
                    "image/eps",
                    "image/pict"
                };
                foreach (var types in imageTypes)
                {
                    if (image.ContentType.Contains(types))
                    {
                        return true;
                    }

                }
                return false;
            }
        }
    }
    
}
