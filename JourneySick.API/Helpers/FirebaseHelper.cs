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
            string DirDebug = DirProject();

            //Firebase SDKs
            /*FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile(""),
                ProjectId = firebaseSettings.ProjectId,
                ServiceAccountId = firebaseSettings.ServiceAccountId
            });*/

            return services;
        }

        public static string DirProject()
        {
            string DirDebug = System.IO.Directory.GetCurrentDirectory();
            string DirProject = DirDebug;

            for (int counter_slash = 0; counter_slash < 4; counter_slash++)
            {
                DirProject = DirProject.Substring(0, DirProject.LastIndexOf(@"\"));
            }

            return DirProject;
        }
    }
}
