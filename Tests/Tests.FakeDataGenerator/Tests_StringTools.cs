using System;
using System.Globalization;
using FakeDataGenerator;
using NUnit.Framework;

namespace Tests.FakeDataGenerator
{
    [TestFixture]
    [TestOf(nameof(StringTools))]
    [Parallelizable(ParallelScope.All)]
    public class Tests_StringTools : Randomiser
    {
        private static readonly Array __unicodeCategoryArray = Enum.GetValues(typeof(UnicodeCategory));

        #region Random()

        [Test]
        public void Test_Random()
        {
            //Arrange
            //Action
            var text = StringTools.Random();


            //Assert
            Assert.IsNotNull(text);
            Assert.IsNotEmpty(text);
        }

        #endregion Random()

        #region Random(ushort length)

        [Test]
        public void Test_Random__length_should_return_same_length()
        {
            //Arrange
            ushort length = (ushort)__random.Value.Next(ushort.MaxValue);

            //Action
            string text = StringTools.Random(length);


            //Assert
            Assert.IsNotNull(text);
            Assert.AreEqual(length, text.Length);
        }

        [Test]
        public void Test_Random__MAX_length_return_same()
        {
            //Arrange
            //Action
            var text = StringTools.Random(ushort.MaxValue);


            //Assert
            Assert.IsNotNull(text);
            Assert.AreEqual(ushort.MaxValue, text.Length);
        }

        [Test]
        public void Test_Random__MIN_length_return_0_string()
        {
            //Arrange
            //Action
            var text = StringTools.Random(ushort.MinValue);


            //Assert
            Assert.IsNotNull(text);
            Assert.AreEqual(ushort.MinValue, text.Length);
        }

        #endregion Random(ushort length)

        #region Random(params UnicodeCategory[] characters)

        [Test]
        public void Test_Random_UnicodeCategory__should_return_just_UppercaseLetters_and_ClosePunctuation()
        {
            //Arrange
            //Action
            var text = StringTools.Random(UnicodeCategory.UppercaseLetter, UnicodeCategory.ClosePunctuation);


            //Assert
            Assert.IsNotNull(text);
            Assert.IsNotEmpty(text);

            foreach (char c in text)
            {
                UnicodeCategory uc = char.GetUnicodeCategory(c);
                var isCorrectUnicodeCategory = uc == UnicodeCategory.UppercaseLetter || uc == UnicodeCategory.ClosePunctuation;
                Assert.IsTrue(isCorrectUnicodeCategory);
            }
        }

        [Test]
        [TestCaseSource(nameof(__unicodeCategoryArray))]
        public void Test_Random_UnicodeCategory__all_UnicodeCategories_should_return_correct_values(UnicodeCategory ucc)
        {
            //Arrange
            //Action
            string text = StringTools.Random(ucc);


            //Assert
            Assert.IsNotNull(text);
            Assert.IsNotEmpty(text);

            foreach (char c in text)
            {
                UnicodeCategory uc = char.GetUnicodeCategory(c);
                Assert.AreEqual(ucc, uc);
            }
        }

        #endregion Random(params UnicodeCategory[] characters)

        #region Random(ushort length, params char[] characters)

        [Test]
        public void Test_Random_length_UnicodeCategory__MIN_length_return_0_string_()
        {
            //Arrange
            //Action
            var text = StringTools.Random(ushort.MinValue, UnicodeCategory.UppercaseLetter);


            //Assert
            Assert.IsNotNull(text);
            Assert.AreEqual(ushort.MinValue, text.Length);
        }

        [Test]
        public void Test_Random_length_UnicodeCategory__should_return_just_UppercaseLetters_and_ClosePunctuation()
        {
            //Arrange
            ushort length = (ushort)__random.Value.Next(ushort.MaxValue);


            //Action
            var text = StringTools.Random(length, UnicodeCategory.UppercaseLetter, UnicodeCategory.ClosePunctuation);


            //Assert
            Assert.IsNotNull(text);
            Assert.AreEqual(length, text.Length);

            foreach (char c in text)
            {
                UnicodeCategory uc = char.GetUnicodeCategory(c);
                var isCorrectUnicodeCategory = uc == UnicodeCategory.UppercaseLetter || uc == UnicodeCategory.ClosePunctuation;
                Assert.IsTrue(isCorrectUnicodeCategory);
            }
        }

        [Test]
        [TestCaseSource(nameof(__unicodeCategoryArray))]
        public void Test_Random_length_UnicodeCategory__all_UnicodeCategories_should_return_correct_values(UnicodeCategory ucc)
        {
            //Arrange
            int randomMaxValue;

            switch (ucc)
            {
                case UnicodeCategory.ParagraphSeparator:
                case UnicodeCategory.SpaceSeparator:
                    randomMaxValue = 5;

                    break;
                default:
                    randomMaxValue = ushort.MaxValue;

                    break;
            }

            ushort length = (ushort)__random.Value.Next(randomMaxValue);


            //Action
            string text = StringTools.Random(length, ucc);


            //Assert
            Assert.IsNotNull(text);
            Assert.AreEqual(length, text.Length);

            foreach (char c in text)
            {
                UnicodeCategory uc = char.GetUnicodeCategory(c);
                Assert.AreEqual(ucc, uc);
            }
        }

        #endregion Random(ushort length, params char[] characters)


    }
}