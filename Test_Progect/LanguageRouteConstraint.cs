using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;
using System.Globalization;

namespace Test_Progect
{
    public class LanguageRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (!values.ContainsKey("lang"))
            {
                return false;
            }

            var lang = values["lang"].ToString();

            return lang == "ua" || lang == "en";
        }
    }

    public class LocalizationPipeline
    {
        public void Configure(IApplicationBuilder app)
        {

            var supportedCultures = new List<CultureInfo>
                                {
                                    new CultureInfo("ua"),
                                    new CultureInfo("en"),
                                };

            var options = new RequestLocalizationOptions()
            {

                DefaultRequestCulture = new RequestCulture(culture: "ua", uiCulture: "ua"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            };

            options.RequestCultureProviders = new[] { new RouteDataRequestCultureProvider() { Options = options, RouteDataStringKey = "lang", UIRouteDataStringKey = "lang" } };

            app.UseRequestLocalization(options);
        }
    }
}