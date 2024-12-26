using System.Globalization;

namespace Api.Middleware
{
    public class CultureMiddleware
    {
        private readonly RequestDelegate _next;
        private static readonly List<string> _supportedLanguages = ["en", "pt-BR"];

        public CultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

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

            return cultureExists ? requestedCulture! : "en";
        }

        private static void SetCulture(string culture)
        {
            CultureInfo cultureInfo = new(culture);

            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;
        }
    }
}
