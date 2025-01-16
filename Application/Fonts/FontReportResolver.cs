using PdfSharp.Fonts;
using System.Reflection;

namespace Application.Fonts
{
    public class FontReportResolver : IFontResolver
    {

        public byte[]? GetFont(string faceName)
        {
            var stream = ReadFontFile(faceName);

            stream ??= ReadFontFile(FontNames.DEFAULT);

            using var memoryStream = new MemoryStream();
            stream!.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }

        public FontResolverInfo? ResolveTypeface(string familyName, bool bold, bool italic)
        {
            return new FontResolverInfo(familyName, bold, italic);
        }

        private static Stream? ReadFontFile(string faceName)
        {
            return 
                Assembly
                .GetExecutingAssembly()
                .GetManifestResourceStream($"Application.Fonts.{faceName}.ttf");
        }
    }
}
