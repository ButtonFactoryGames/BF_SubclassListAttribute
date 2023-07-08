using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BF_SubclassList
{
    public static class Helpers
    {
        public static string GetMiddleString(this string @string, string start, string end)
        {
            int pFrom = @string.IndexOf(start) + start.Length;
            int pTo = @string.LastIndexOf(end);
            return @string.Substring(pFrom, pTo - pFrom);
        }
    }
}