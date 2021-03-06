﻿using System.Globalization;

namespace FakeDataGenerator
{
    public static class CharacterTools
    {
        public static UnicodeCategoryCharacter[] UnicodeCategoryCharacters { get; } = new UnicodeCategoryCharacter[char.MaxValue];

        static CharacterTools()
        {
            for (int i = 0; i < char.MaxValue; i++)
            {
                char c = (char)i;
                UnicodeCategory uc = char.GetUnicodeCategory(c);
                var ucc = new UnicodeCategoryCharacter(c, uc);
                UnicodeCategoryCharacters[i] = ucc;
            }
        }
    }
}