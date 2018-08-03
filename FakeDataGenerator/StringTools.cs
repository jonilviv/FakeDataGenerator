using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace FakeDataGenerator
{
    public static class StringTools
    {
        private static int _seed = Environment.TickCount;
        private static readonly ThreadLocal<Random> __random = new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref _seed)));

        public static string Random()
        {
            int length = __random.Value.Next();
            string result = Random((ushort)length);

            return result;
        }

        public static string Random(ushort length)
        {
            StringBuilder result = new StringBuilder(length);

            while (result.Length < length)
            {
                char c = (char)__random.Value.Next(char.MaxValue);

                result.Append(c);
            }

            return result.ToString();
        }


        public static string Random(params UnicodeCategory[] characters)
        {
            ushort length = (ushort)__random.Value.Next(char.MaxValue);
            string result = Random(length, characters);

            return result;
        }

        public static string Random(ushort length, params UnicodeCategory[] characters)
        {
            char[] chars = CharacterTools.UnicodeCategoryCharacters.Where(x => characters.Contains(x.UnicodeCategory)).Select(x => x.Char).ToArray();
            int charsLength = chars.Length;
            StringBuilder result = new StringBuilder(length);

            while (result.Length < length)
            {
                char c = chars[__random.Value.Next(charsLength)];
                result.Append(c);
            }

            return result.ToString();
        }


        public static string Random(ushort minCharacterIndex, ushort maxCharacterIndex)
        {
            ushort length = (ushort)__random.Value.Next(char.MaxValue);
            string result = Random(length, minCharacterIndex, maxCharacterIndex);

            return result;
        }

        public static string Random(ushort length, ushort minCharacterIndex, ushort maxCharacterIndex)
        {
            StringBuilder result = new StringBuilder(length);

            while (result.Length < length)
            {
                char c = (char)__random.Value.Next(minCharacterIndex, maxCharacterIndex);
                result.Append(c);
            }

            return result.ToString();
        }


    }
}