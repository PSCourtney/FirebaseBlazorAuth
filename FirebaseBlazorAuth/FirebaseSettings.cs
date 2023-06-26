namespace FirebaseBlazorAuth
{

    public class FirebaseSettings
    {

        public string? FirebaseApiKey { get; set; }

        public string? FirebaseAuthDomain { get; set; }

        public string? ProjectId { get; set; }

        public string? StorageBucket { get; set; }

        public string? MessagingSenderId {get; set; }

        public string AppId { get; set; }

        public string MeasurementId { get; set; }


        public FirebaseSettings()
        {
            FirebaseApiKey = string.Empty;

            FirebaseAuthDomain = string.Empty;

            ProjectId = string.Empty; 

            StorageBucket = string.Empty;

            MessagingSenderId = string.Empty;

            AppId = string.Empty;

            MeasurementId = string.Empty;

        }
    }
}
