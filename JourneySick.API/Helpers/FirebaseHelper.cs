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

            firebaseDir += "\\Firebase\\journeysick-34101-firebase-adminsdk-dqbsf-754e3cf28e.json";

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
