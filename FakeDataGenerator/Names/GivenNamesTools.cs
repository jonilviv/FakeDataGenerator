using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace FakeDataGenerator.Names
{
    public static class GivenNamesTools
    {
        private static readonly Random __random = new Random();
        private static readonly CultureInfo __enCultureInfo = CultureInfo.GetCultureInfo("en");

        public static List<GivenName> GivenNames { get; } = new List<GivenName>
        {
            #region English

            #region Male

            new GivenName{Culture = __enCultureInfo, Sex = Sex.Male, Name = "Alexander"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Male, Name = "Callum"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Male, Name = "Charles"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Male, Name = "Connor"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Male, Name = "Damian"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Male, Name = "Daniel"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Male, Name = "David"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Male, Name = "Ethan"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Male, Name = "George"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Male, Name = "Harry"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Male, Name = "Jack"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Male, Name = "Jacob"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Male, Name = "Jake"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Male, Name = "James"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Male, Name = "Joe"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Male, Name = "John"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Male, Name = "Joseph"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Male, Name = "Kyle"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Male, Name = "Liam"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Male, Name = "Mason"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Male, Name = "Michael"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Male, Name = "Noah"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Male, Name = "Oliver"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Male, Name = "Oscar"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Male, Name = "Reece"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Male, Name = "Rhys"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Male, Name = "Richard"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Male, Name = "Robert"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Male, Name = "Thomas"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Male, Name = "Thomas"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Male, Name = "William"},

            #endregion Male

            #region Female

            new GivenName{Culture = __enCultureInfo, Sex = Sex.Female, Name = "Abigail"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Female, Name = "Amelia"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Female, Name = "Ava"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Female, Name = "Barbara"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Female, Name = "Bethany"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Female, Name = "Charlotte"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Female, Name = "Elizabeth"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Female, Name = "Emily"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Female, Name = "Emma"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Female, Name = "Isabella"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Female, Name = "Isla"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Female, Name = "Jennifer"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Female, Name = "Jessica"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Female, Name = "Joanne"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Female, Name = "Lauren"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Female, Name = "Lily"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Female, Name = "Linda"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Female, Name = "Madison"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Female, Name = "Margaret"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Female, Name = "Mary"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Female, Name = "Megan"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Female, Name = "Mia"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Female, Name = "Michelle"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Female, Name = "Olivia"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Female, Name = "Patricia"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Female, Name = "Poppy"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Female, Name = "Samantha"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Female, Name = "Sarah"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Female, Name = "Sophia"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Female, Name = "Susan"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Female, Name = "Tracy"},
            new GivenName{Culture = __enCultureInfo, Sex = Sex.Female, Name = "Victoria"},
            
            #endregion Female

            #endregion English
        };

        public static IEnumerable<GivenName> Culture(this IEnumerable<GivenName> givenNames, CultureInfo culture)
        {
            IEnumerable<GivenName> result = givenNames.Where(x => Equals(x.Culture, culture));

            return result;
        }

        public static IEnumerable<GivenName> Culture(this IEnumerable<GivenName> givenNames, string culture)
        {
            var ci = CultureInfo.GetCultureInfo(culture);

            var result = Culture(givenNames, ci);

            return result;
        }

        public static GivenName Random(this IEnumerable<GivenName> givenNames)
        {
            if (givenNames == null || !givenNames.Any())
            {
                return null;
            }

            int i = __random.Next(givenNames.Count() + 1);
            GivenName result = givenNames.ElementAt(i);

            return result;
        }
    }
}