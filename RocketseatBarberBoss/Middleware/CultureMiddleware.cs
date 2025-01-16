using System.Globalization;

namespace Api.Middleware
{
    public class CultureMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;
        private static readonly List<string> _supportedLanguages = ["en-US", "pt-BR"];

        public async Task Invoke(HttpContext context)
        {
            var requestedCulture = GetRequestedCulture(context);

            SetCulture(requestedCulture);

            await _next(context);
        }

        private static string GetRequestedCulture(HttpContext context)
        {
            var requestedCulture = context.Request.Headers.AcceptLanguage.FirstOrDefault();

            var cultureExists = _supportedLanguages.Contains(requestedCulture ?? string.Empty);

            return cultureExists ? requestedCulture! : "en-US";
        }

        private static void SetCulture(string culture)
        {
            CultureInfo cultureInfo = new(culture);

            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;
        }
    }
}
