using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    internal static class Operation
    {

        public static event Func<string, string, string> Add;
        public static event Func<string, string> RemoveMarks;
        public static event Func<string, string> Upper;
        public static event Predicate<string> Search;
        public static event Action<string> Show;

        public static string? AddStr(string str, string str2) => Add?.Invoke(str, str2);
        public static string? RemoveMarksStr(string str) => RemoveMarks?.Invoke(str);
        public static string? UpperStr(string str) => Upper?.Invoke(str);
        public static bool SearchStr(string str) => Search.Invoke(str);

        public static void ShowStr(string str) => Show.Invoke(str);
    }
}
