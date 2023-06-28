using Firebase.Auth;
using Firebase.Storage;
using JourneySick.Business.Helpers.SettingObject;
using JourneySick.Business.IServices.Services;
using JourneySick.Data.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Business.Extensions.Firebase.Impl
{
    public class FirebaseStorageService : IFirebaseStorageService
    {
        private readonly FirebaseSetting _firebaseSetting;
        private readonly ILogger<FirebaseStorageService> _logger;

        public FirebaseStorageService(IOptions<FirebaseSetting> firebaseSetting,
            ILogger<FirebaseStorageService> logger)
        {
            _firebaseSetting = firebaseSetting.Value;
            _logger = logger;
        }
        public async Task<string> UploadTripThumbnail(IFormFile thumbnail, string tripId)
        {
            try
            {
/*                var tokenDescriptor = new Dictionary<string, object>()
                {
                    {"permission", "allow" }
                };*/

                //string storageToken = await FirebaseAdmin.Auth.FirebaseAuth.DefaultInstance.CreateCustomTokenAsync(tripId, tokenDescriptor);
                var auth = new FirebaseAuthProvider(new FirebaseConfig(_firebaseSetting.ApiKey));

                var token = await auth.SignInWithEmailAndPasswordAsync(_firebaseSetting.Email, _firebaseSetting.Password);

                var uploadTask = new FirebaseStorage(
                                     _firebaseSetting.Bucket,
                                     new FirebaseStorageOptions
                                     {
                                         AuthTokenAsyncFactory = () => Task.FromResult(token.FirebaseToken),
                                         ThrowOnCancel = true,
                                     }).Child("Images").Child("Trip").Child("Thumbnail").Child(tripId).PutAsync(thumbnail.OpenReadStream());

                var downloadUrl = await uploadTask;


                return downloadUrl.ToString();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<string> UploadAvatar(IFormFile thumbnail, string userId)
        {
            try
            {
                /*                var tokenDescriptor = new Dictionary<string, object>()
                                {
                                    {"permission", "allow" }
                                };*/

                //string storageToken = await FirebaseAdmin.Auth.FirebaseAuth.DefaultInstance.CreateCustomTokenAsync(tripId, tokenDescriptor);
                var auth = new FirebaseAuthProvider(new FirebaseConfig(_firebaseSetting.ApiKey));

                var token = await auth.SignInWithEmailAndPasswordAsync(_firebaseSetting.Email, _firebaseSetting.Password);

                var uploadTask = new FirebaseStorage(
                                     _firebaseSetting.Bucket,
                                     new FirebaseStorageOptions
                                     {
                                         AuthTokenAsyncFactory = () => Task.FromResult(token.FirebaseToken),
                                         ThrowOnCancel = true,
                                     }).Child("Images").Child("User").Child("Avatar").Child(userId).PutAsync(thumbnail.OpenReadStream());

                var downloadUrl = await uploadTask;


                return downloadUrl.ToString();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<string> UpdateTripThumbnail(IFormFile thumbnail, string tripId)
        {
            try
            {
                var auth = new FirebaseAuthProvider(new FirebaseConfig(_firebaseSetting.ApiKey));

                var token = await auth.SignInWithEmailAndPasswordAsync(_firebaseSetting.Email, _firebaseSetting.Password);

                var uploadTask = new FirebaseStorage(
                                     _firebaseSetting.Bucket,
                                     new FirebaseStorageOptions
                                     {
                                         AuthTokenAsyncFactory = () => Task.FromResult(token.FirebaseToken),
                                         ThrowOnCancel = true,
                                     }).Child("Images").Child("Trip").Child("Thumbnail").Child(tripId).PutAsync(thumbnail.OpenReadStream());

                var downloadUrl = await uploadTask;


                return downloadUrl.ToString();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }
    }
}
