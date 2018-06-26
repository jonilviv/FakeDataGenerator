using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using FakeDataGenerator.Names;
using NUnit.Framework;

namespace Tests.FakeDataGenerator.Names
{
    [TestFixture]
    public sealed class Tests_GivenNamesTools
    {
        [Test]
        public void Test_GivenNamesTools__GivenNames_returns_english_names_with_both_sex()
        {
            //Arrange
            CultureInfo ci = CultureInfo.GetCultureInfo("en");


            //Act
            List<GivenName> names = GivenNamesTools.GivenNames;


            //Assert
            IEnumerable<GivenName> enNames = names.Where(x => Equals(x.Culture, ci));
            Assert.IsNotNull(enNames);
            Assert.IsNotEmpty(enNames);

            IEnumerable<GivenName> enMaleNames = enNames.Where(x => x.Sex == Sex.Male);
            Assert.IsNotNull(enMaleNames);
            Assert.IsNotEmpty(enMaleNames);

            IEnumerable<GivenName> enFemaleNames = enNames.Where(x => x.Sex == Sex.Female);
            Assert.IsNotNull(enFemaleNames);
            Assert.IsNotEmpty(enFemaleNames);
        }

        [Test]
        public void Test_GivenNamesTools__Culture_returns_english_names_with_both_sex()
        {
            //Arrange
            CultureInfo ci = CultureInfo.GetCultureInfo("en");


            //Act
            IEnumerable<GivenName> names = GivenNamesTools.GivenNames.Culture(ci);


            //Assert
            IEnumerable<GivenName> enNames = names.Where(x => Equals(x.Culture, ci));
            Assert.IsNotNull(enNames);
            Assert.IsNotEmpty(enNames);

            IEnumerable<GivenName> enMaleNames = enNames.Where(x => x.Sex == Sex.Male);
            Assert.IsNotNull(enMaleNames);
            Assert.IsNotEmpty(enMaleNames);

            IEnumerable<GivenName> enFemaleNames = enNames.Where(x => x.Sex == Sex.Female);
            Assert.IsNotNull(enFemaleNames);
            Assert.IsNotEmpty(enFemaleNames);
        }

        [Test]
        public void Test_GivenNamesTools__Culture_returns_english_names_with_both_sex_()
        {
            //Arrange
            CultureInfo ci = CultureInfo.GetCultureInfo("en");


            //Act
            IEnumerable<GivenName> names = GivenNamesTools.GivenNames.Culture("en");


            //Assert
            IEnumerable<GivenName> enNames = names.Where(x => Equals(x.Culture, ci));
            Assert.IsNotNull(enNames);
            Assert.IsNotEmpty(enNames);

            IEnumerable<GivenName> enMaleNames = enNames.Where(x => x.Sex == Sex.Male);
            Assert.IsNotNull(enMaleNames);
            Assert.IsNotEmpty(enMaleNames);

            IEnumerable<GivenName> enFemaleNames = enNames.Where(x => x.Sex == Sex.Female);
            Assert.IsNotNull(enFemaleNames);
            Assert.IsNotEmpty(enFemaleNames);
        }

        [Test]
        public void Test_GivenNamesTools__Random_empty_list_returns_null_GivenName()
        {
            //Arrange
            //Act
            GivenName name = new List<GivenName>().Random();


            //Assert
            Assert.Null(name);
        }

        [Test]
        public void Test_GivenNamesTools__Random_returns_some_name()
        {
            //Arrange
            //Act
            GivenName name = GivenNamesTools.GivenNames.Random();


            //Assert
            Assert.IsNotNull(name);
            Assert.IsNotNull(name.Sex);
            Assert.IsNotNull(name.Culture);
            Assert.IsNotNull(name.Name);
            Assert.IsNotEmpty(name.Name);
        }

    }
}