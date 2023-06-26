using Firebase.Auth.Providers;
using Microsoft.AspNetCore.Components;
using System.Security.Claims;
using FirebaseBlazorAuth.Services;
using Firebase.Auth;
using MudBlazor;
using System.Text.RegularExpressions;

namespace FirebaseBlazorAuth.Pages.Auth
{
    public partial class Login : ComponentBase
    {

        [Inject]
        CustomAuthStateProvider? _authProvider { get; set; }

        [Inject]
        FirebaseSettings? _firebaseSettings { get; set; }
        [Inject]
        NavigationManager? _navigationManager { get; set; }

        private string[] LoginErrors = { };

        private string[] SignUpErrors = { };

        private bool LoginSuccess { get; set; }

        private bool SignUpSuccess { get; set; }
        bool ShowErrorMessage { get; set; }
        string ErrorMessage { get; set; }

        MudTextField<string> _signUpEmail { get; set; }
        MudTextField<string> _signUpPassword { get; set; }

        MudTextField<string> _loginEmail { get; set; }
        MudTextField<string> _loginPassword { get; set; }
        MudForm form;

        private async Task SignIn()
        {
            if (form.IsValid)
            {
                FirebaseAuthService firebaseAuthService = new FirebaseAuthService(_firebaseSettings);
                FirebaseAuthService.UserCredentialData? userCredential = await firebaseAuthService.SignInWithEmail(_loginEmail.Value, _loginPassword.Value);

                if (userCredential?.UserData != null)
                {
                    await _authProvider.UpdateSignInStatusAsync(new ClaimsPrincipal(
                        new ClaimsIdentity(
                            new Claim[]
                            {
                    new (_loginEmail.Value, _loginPassword.Value),
                            },
                            "Custom"
                        )
                    ));

                    _navigationManager.NavigateTo("/account");
                }

                if (userCredential?.AuthErrorReason == AuthErrorReason.WrongPassword)
                {
                    ShowErrorMessage = true;
                    ErrorMessage = "Wrong password";
                }

                if (userCredential?.AuthErrorReason == AuthErrorReason.UnknownEmailAddress)
                {
                    ShowErrorMessage = true;
                    ErrorMessage = "You are not currently registered. Please sign up.";
                }

              
            }
        }

        public IEnumerable<string> PasswordStrength(string pw)
        {
            if (string.IsNullOrWhiteSpace(pw))
            {
                yield return "Password is required!";
                yield break;
            }
            if (pw.Length < 6)
                yield return "Password must be at least of length 6";
            if (!Regex.IsMatch(pw, @"[A-Z]"))
                yield return "Password must contain at least one capital letter";
            if (!Regex.IsMatch(pw, @"[a-z]"))
                yield return "Password must contain at least one lowercase letter";
            if (!Regex.IsMatch(pw, @"[0-9]"))
                yield return "Password must contain at least one digit";
        }

        private string PasswordMatch(string arg)
        {
            if (_signUpPassword.Value != arg)
                return "Passwords don't match";
            return null;
        }

    }
}
                
          