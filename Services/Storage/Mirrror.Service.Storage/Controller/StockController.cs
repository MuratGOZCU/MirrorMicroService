using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mirrror.Service.Storage.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mirrror.Service.Storage.Controller
{
    [Route("api/[controller]")]
    public class StockController : Microsoft.AspNetCore.Mvc.Controller
    {
       

        [HttpPost("PhotoSave")]
        public async Task<PhotoModel> PhotoSave(IFormFile photo, CancellationToken cancellationToken)
        {
            if (photo != null && photo.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files", photo.FileName);

                using var stream = new FileStream(path, FileMode.Create);
                await photo.CopyToAsync(stream, cancellationToken);

                var returnPath = photo.FileName;

                PhotoModel photoModel = new() { Url = returnPath };

                return photoModel;
            }

            return new PhotoModel() { Url = "" };
        }


    }
}

