using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NutriAnimal.Services
{
    public interface ICLoudinaryService
    {

        Task<string> UploadPicture(IFormFile pictureFile,string fileName);
            
    }
}
