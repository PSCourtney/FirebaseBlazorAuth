using Firebase.Auth.Providers;
using Firebase.Auth;
using System.Net;
using Microsoft.AspNetCore.Components;

namespace FirebaseBlazorAuth.Services
{
    public class FirebaseAuthService
    {
        private readonly FirebaseAuthConfig config;

        public class UserCredentialData{
            public UserCredential? UserData { get; set; }

            public AuthErrorReason? AuthErrorReason { get; set; }
        }

        public FirebaseAuthService(FirebaseSettings firebaseSettings)
        {
            config = new FirebaseAuthConfig
            {
                ApiKey = firebaseSettings.FirebaseApiKey,
                AuthDomain = firebaseSettings.FirebaseAuthDomain,
                
                Providers = new FirebaseAuthProvider[]
                {
                            new EmailProvider(),

                            
                }
            };
        }

        /// <summary>
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public async Task<UserCredentialData?> SignInWithEmail(string? email, string? password)
        {
            UserCredentialData? userCredential = new();
            userCredential.UserData = null;

            try
            {
                FirebaseAuthClient client = new FirebaseAuthClient(config);

                FetchUserProvidersResult result = await client.FetchSignInMethodsForEmailAsync(email);

                if (result.UserExists && result.AllProviders.Contains(FirebaseProviderType.EmailAndPassword))
                {
                    userCredential.UserData = await client.SignInWithEmailAndPasswordAsync(email, password);
                }
                else
                {
                    userCredential.AuthErrorReason = AuthErrorReason.UnknownEmailAddress;
                }
            }
            catch (FirebaseAuthException ex)
            {
                userCredential.AuthErrorReason = ex.Reason;
            }

            return userCredential;
        }

        public void Signout()
        {
            FirebaseAuthClient firebaseAuthClient = new FirebaseAuthClient(config);
            firebaseAuthClient.SignOut();
        }
    }
}
