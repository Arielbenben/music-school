using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace PracticeFunc.Service
{
    internal class Practice
    {
        public static Func<List<string>, bool> IsBeginInA = s =>
        s.Any(s => s.StartsWith("a"));

        public static Func<List<string>, bool> IsStringEmpty = s =>
        s.Any(string.IsNullOrEmpty);

        public static Func<List<string>, bool> IsAllContainsA = s =>
        s.All(s => s.Contains("a"));

        public static Func<List<string>, List<string>> ToUpperCase = (s) =>
        s.Select(s => s.ToUpper()).ToList();

        public static Func<List<string>, List<string>> ToUpperCase2 = (s) =>
        s.Aggregate(new List<string>(), (res, nextEl) => [.. res, nextEl.ToUpper()]);

        public static Func<List<string>, List<string>> ToUpperCaseWithFrom = list =>
        (from str in list select str.ToUpper()).ToList();

        public static Func<List<string>, List<string>> IsLongThan3 = list =>
        list.Where(s => s.Length > 3).ToList();

        public static Func<List<string>, List<string>> IsLongThan3From = list =>
        (from str in list where str.Length > 3 select str).ToList();

        public static Func<List<string>, string> CombineToString = list =>
        list.Aggregate(string.Empty, (res, nextEl) => $"{res}  {nextEl}");

        public static Func<List<string>, int> CombineByLenght = list =>
        list.Aggregate(0, (res, nextel) => res + nextel.Length);

        public static Func<List<string>, List<string>> IsLenghtBigThan3ByAggre = list =>
        list.Aggregate(new List<string>(), (res, nextel) => nextel.Length > 3 ? [.. res, nextel] : res);

        public static Func<List<string>, List<int>> ListToListInt = list => list.
        Aggregate(new List<int>(), (res, nextEl) => [.. res, nextEl.Length]);


        /*public static bool Is(string a) { return a.Length > 3; }
        public static string Isnn(string a) => a.Length > 3 ? "Yaaa" : "Damm";

        public static string IsNUll(string d) => string.IsNullOrEmpty(d) ? "Yaaa" : "Damm";*/
    }
}