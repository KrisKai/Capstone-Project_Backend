using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using JourneySick.Business.Helpers.SettingObject;

namespace JourneySick.API.Helpers
{
    public static class FirebaseHelper
    {
        public static IServiceCollection AddFirebaseSDK(this IServiceCollection services, IConfiguration configuration)
        {
            ///Firebase storage
            var firebaseSettingSection = configuration.GetSection("FirebaseSettings");
            services.Configure<FirebaseSetting>(firebaseSettingSection);
            var firebaseSettings = firebaseSettingSection.Get<FirebaseSetting>();
            string firebaseDir = System.IO.Directory.GetCurrentDirectory();

            firebaseDir += "\\Firebase\\journeysick-56add-firebase-adminsdk-3m0he-78b2965ca7.json";

            //Firebase SDKs
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile(firebaseDir),
                ProjectId = firebaseSettings.ProjectId,
                ServiceAccountId = firebaseSettings.ServiceAccountId
            });

            return services;
        }
    }
}
