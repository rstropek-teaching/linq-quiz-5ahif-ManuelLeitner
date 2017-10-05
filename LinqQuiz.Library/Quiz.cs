using System;
using System.Collections.Generic;
using System.Linq;
using static System.Linq.Enumerable;

namespace LinqQuiz.Library {
    public static class Quiz {
        /// <summary>
        /// Returns all even numbers between 1 and the specified upper limit.
        /// </summary>
        /// <param name="exclusiveUpperLimit">Upper limit (exclusive)</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown if <paramref name="exclusiveUpperLimit"/> is lower than 1.
        /// </exception>
        public static int[] GetEvenNumbers(int exclusiveUpperLimit) {
            return Range(1, exclusiveUpperLimit - 1).Where(v => v % 2 == 0).ToArray();
        }

        /// <summary>
        /// Returns the squares of the numbers between 1 and the specified upper limit 
        /// that can be divided by 7 without a remainder (see also remarks).
        /// </summary>
        /// <param name="exclusiveUpperLimit">Upper limit (exclusive)</param>
        /// <exception cref="OverflowException">
        ///     Thrown if the calculating the square results in an overflow for type <see cref="System.Int32"/>.
        /// </exception>
        /// <remarks>
        /// The result is an empty array if <paramref name="exclusiveUpperLimit"/> is lower than 1.
        /// The result is in descending order.
        /// 
        /// If a number is devisible by any number its square is also divisible.
        /// If the square is devisible by a prime the squareroot is also divisible.
        /// 7 is prime.
        /// 
        /// Enumerable.Range is sorted ascending automatically, reversing it makes the data sorted descending.
        /// </remarks>
        public static int[] GetSquares(int exclusiveUpperLimit) {
            return Range(1, exclusiveUpperLimit<0?0: (exclusiveUpperLimit-1) / 7).Select(v => checked(v * v * 49)).Reverse().ToArray();
        }

        /// <summary>
        /// Returns a statistic about families.
        /// </summary>
        /// <param name="families">Families to analyze</param>
        /// <returns>
        /// Returns one statistic entry per family in <paramref name="families"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref name="families"/> is <c>null</c>.
        /// </exception>
        /// <remarks>
        /// <see cref="FamilySummary.AverageAge"/> is set to 0 if <see cref="IFamily.Persons"/>
        /// in <paramref name="families"/> is empty.
        /// </remarks>
        public static FamilySummary[] GetFamilyStatistic(IReadOnlyCollection<IFamily> families) {
            return families.Select(fam => new FamilySummary( fam.ID, fam.Persons.Count, fam.Persons.DefaultIfEmpty().Average(pers => pers?.Age??0))).ToArray();
        }

        /// <summary>
        /// Returns a statistic about the number of occurrences of letters in a text.
        /// </summary>
        /// <param name="text">Text to analyze</param>
        /// <returns>
        /// Collection containing the number of occurrences of each letter (see also remarks).
        /// </returns>
        /// <remarks>
        /// Casing is ignored (e.g. 'a' is treated as 'A'). Only letters between A and Z are counted;
        /// special characters, numbers, whitespaces, etc. are ignored. The result only contains
        /// letters that are contained in <paramref name="text"/> (i.e. there must not be a collection element
        /// with number of occurrences equal to zero.
        /// </remarks>
        public static (char letter, int numberOfOccurrences)[] GetLetterStatistic(string text) {
            return text.ToArray().Where(c=>char.IsLetter(c)).GroupBy(c => c).Select(g => (g.Key, g.Count())).ToArray();
        }
    }
}
