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
            ushort length = (ushort)__random.Value.Next(char.MaxValue);

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
            var text = StringTools.Random(char.MaxValue);


            //Assert
            Assert.IsNotNull(text);
            Assert.AreEqual(char.MaxValue, text.Length);
        }

        [Test]
        public void Test_Random__MIN_length_return_0_string()
        {
            //Arrange
            //Action
            var text = StringTools.Random(char.MinValue);


            //Assert
            Assert.IsNotNull(text);
            Assert.AreEqual(char.MinValue, text.Length);
        }

        #endregion Random(ushort length)

        #region Random(params UnicodeCategory[] characters)

        [Test]
        public void Test_Random_UnicodeCategory__should_return_just_UppercaseLetters_and_ClosePunctuation()
        {
            //Arrange
            //Action
            string text = StringTools.Random(UnicodeCategory.UppercaseLetter, UnicodeCategory.ClosePunctuation);


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
            string text = StringTools.Random(char.MinValue, UnicodeCategory.UppercaseLetter);


            //Assert
            Assert.IsNotNull(text);
            Assert.AreEqual(char.MinValue, text.Length);
        }

        [Test]
        public void Test_Random_length_UnicodeCategory__should_return_just_UppercaseLetters_and_ClosePunctuation()
        {
            //Arrange
            ushort length = (ushort)__random.Value.Next(char.MaxValue);


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
            ushort length = (ushort)__random.Value.Next(char.MaxValue);


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

        #region Random(ushort minCharacterIndex, ushort maxCharacterIndex)

        [Test]
        public void Test_Random_min_greater_than_max_should_raise_exception()
        {
            //Arrange
            //Act
            //Assert

            Assert.Throws<ArgumentOutOfRangeException>(() => StringTools.Random(char.MaxValue, char.MinValue));
        }

        [Test]
        public void Test_Random_min_max_should_return_just_characters_in_range()
        {
            //Arrange
            ushort min = (ushort)__random.Value.Next(0, char.MaxValue / 2);
            ushort max = (ushort)__random.Value.Next(char.MaxValue / 2, char.MaxValue);

            //Act
            string result = StringTools.Random(min, max);


            //Assert
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result);

            foreach (char c in result)
            {
                Assert.GreaterOrEqual(c, min);
                Assert.LessOrEqual(c, max);
            }
        }

        #endregion Random(ushort minCharacterIndex, ushort maxCharacterIndex)

        #region Random(ushort length, ushort minCharacterIndex, ushort maxCharacterIndex)

        [Test]
        public void Test_Random_length_min_greater_than_max_should_raise_exception()
        {
            //Arrange
            //Act
            //Assert

            Assert.Throws<ArgumentOutOfRangeException>(() => StringTools.Random(ushort.MaxValue, char.MaxValue, char.MinValue));
        }

        [Test]
        public void Test_Random_length_min_max_should_return_just_characters_in_range()
        {
            //Arrange
            ushort length = (ushort)__random.Value.Next(int.MaxValue);
            ushort min = (ushort)__random.Value.Next(0, char.MaxValue / 2);
            ushort max = (ushort)__random.Value.Next(char.MaxValue / 2, char.MaxValue);

            //Act
            string result = StringTools.Random(length, min, max);


            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(length, result.Length);

            foreach (char c in result)
            {
                Assert.GreaterOrEqual(c, min);
                Assert.LessOrEqual(c, max);
            }
        }

        #endregion Random(ushort length, ushort minCharacterIndex, ushort maxCharacterIndex)
    }
}