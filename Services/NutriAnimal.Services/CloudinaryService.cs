using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace NutriAnimal.Services
{
    public class CloudinaryService : ICLoudinaryService
    {
        private readonly Cloudinary CloudinaryUtility;
        public CloudinaryService(Cloudinary CloudinaryUtility)
        {
            this.CloudinaryUtility = CloudinaryUtility;
        }
        public async Task<string> UploadPicture(IFormFile pictureFile, string fileName)
        {
            byte[] destinationData;
            using (var ms = new MemoryStream())
            {
                await pictureFile.CopyToAsync(ms);
                destinationData = ms.ToArray();
            }
            UploadResult uploadResult = null;
            using (var ms = new MemoryStream(destinationData))
            {
                ImageUploadParams uploadParams = new ImageUploadParams
                {
                    Folder = "Product Pictures",
                    File = new FileDescription(fileName, ms)
                };
                uploadResult = this.CloudinaryUtility.Upload(uploadParams);
            }
           return uploadResult?.SecureUri.AbsoluteUri;
        }
    }
}
