using PdfSharp.Fonts;

namespace FoodDev.Models
{
    public interface IFileFontResolver
    {
        string DefaultFontName { get; }

        byte[] GetFont(string faceName);
        FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic);
    }
}