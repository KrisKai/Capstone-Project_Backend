using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Business.Extensions.Firebase
{
    public interface IFirebaseStorageService
    {
        public Task<string> UploadTripThumbnail(IFormFile thumbnail, string tripId);
        public Task<string> UploadAvatar(IFormFile thumbnail, string userId);
    }
}
