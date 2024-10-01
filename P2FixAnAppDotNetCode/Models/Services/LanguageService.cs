using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Data.OData;

namespace P2FixAnAppDotNetCode.Models.Services
{
    /// <summary>
    /// Provides services method to manage the application language
    /// </summary>
    public class LanguageService : ILanguageService
    {
        /// <summary>
        /// Set the UI language
        /// </summary>
        public void ChangeUiLanguage(HttpContext context, string language)
        {
            string culture = SetCulture(language);
            UpdateCultureCookie(context, culture);
        }

        /// <summary>
        /// Set the culture
        /// </summary>
        public string SetCulture(string language)
        {
            string lowerLanguage = language.ToLower().Trim();
            string culture = "en";

            if (lowerLanguage == "french" || lowerLanguage == "francais" || lowerLanguage == "français")
            {
                culture = "fr";
            }
            else if (lowerLanguage == "spanish")
            {
                culture = "es";
            }

            return culture;
        }

        /// <summary>
        /// Update the culture cookie
        /// </summary>
        public void UpdateCultureCookie(HttpContext context, string culture)
        {
            context.Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)));
        }
    }
}
