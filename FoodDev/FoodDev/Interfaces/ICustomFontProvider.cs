namespace FoodDev.Models
{
    public interface ICustomFontProvider
    {
        byte[] GetFont(string faceName);
        string ProvideFont(string familyName, bool isBold, bool isItalic);
    }
}