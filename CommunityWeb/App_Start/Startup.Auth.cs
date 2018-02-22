using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
using CommunityWeb.Models;
using Microsoft.Owin.Security.Facebook;

namespace CommunityWeb
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context, user manager and signin manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // Enables the application to validate the security stamp when the user logs in.
                    // This is a security feature which is used when you change a password or add an external login to your account.  
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });            
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Enables the application to remember the second login verification factor such as phone or email.
            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
            // This is similar to the RememberMe option when you log in.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            // Uncomment the following lines to enable logging in with third party login providers

            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");


            //Facebook login
            
            //var UserInfo = new FacebookAuthenticationOptions();
            //UserInfo.Scope.Add("email");
            //UserInfo.AppId = "251069632095153";
            //UserInfo.AppSecret = "a35a513ba1f5ac23615d25b86387ec43";
            //UserInfo.Provider = new FacebookAuthenticationProvider()
            //{
            //    OnAuthenticated = async context =>
            //    {
            //        context.Identity.AddClaim(new System.Security.Claims.Claim("FacebookAccessToken", context.AccessToken));
            //        foreach (var claim in context.User)
            //        {
            //            var claimType = string.Format("urn:facebook:{0}", claim.Key);
            //            string claimValue = claim.Value.ToString();
            //            if (!context.Identity.HasClaim(claimType, claimValue))
            //                context.Identity.AddClaim(new System.Security.Claims.Claim(claimType, claimValue, "XmlSchemaString", "Facebook"));
            //        }
            //    }
            //};

            //UserInfo.SignInAsAuthenticationType = DefaultAuthenticationTypes.ExternalCookie;
            //app.UseFacebookAuthentication(UserInfo);

            //var facebookAuthenticationOptions = new FacebookAuthenticationOptions()
            //{
            //    AppId = "251069632095153",
            //    AppSecret = "a35a513ba1f5ac23615d25b86387ec43"
            //};
            //facebookAuthenticationOptions.Scope.Add("Email");
            //facebookAuthenticationOptions.Scope.Add("First_Name");
            //facebookAuthenticationOptions.Scope.Add("Last_Name");
            //app.UseFacebookAuthentication(facebookAuthenticationOptions);

            //FacebookAuthenticationOptions fbao = new FacebookAuthenticationOptions();
            //fbao.AppId = "251069632095153";
            //fbao.AppSecret = "a35a513ba1f5ac23615d25b86387ec43";
            //fbao.Scope.Add("email");
            //fbao.Scope.Add("first_name");
            //fbao.Scope.Add("last_name");

            //fbao.SignInAsAuthenticationType = Microsoft.Owin.Security.AppBuilderSecurityExtensions.GetDefaultSignInAsAuthenticationType(app);

            //app.UseFacebookAuthentication(fbao);








            //Facebook login
            app.UseFacebookAuthentication(
               appId: "251069632095153",
               appSecret: "a35a513ba1f5ac23615d25b86387ec43");





            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "",
            //    ClientSecret = ""
            //});
        }
    }
}