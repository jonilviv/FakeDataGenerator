using System.Globalization;

namespace FakeDataGenerator
{
    public class UnicodeCategoryCharacter
    {
        public UnicodeCategoryCharacter(char chr, UnicodeCategory unicodeCategory)
        {
            Char = chr;
            UnicodeCategory = unicodeCategory;
        }

        public char Char { get; }

        public UnicodeCategory UnicodeCategory { get; }
    }
}