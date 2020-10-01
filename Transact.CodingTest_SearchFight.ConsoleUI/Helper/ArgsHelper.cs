using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Transact.CodingTest_SearchFight.ConsoleUI.Helper
{
    /// <summary>
    /// Helper to process console app args
    /// </summary>
    public static class ArgsHelper
    {
        /// <summary>
        /// Get args including those inside quotes
        /// </summary>
        /// <param name="argsString"></param>
        /// <returns><see cref="List{T}"/></returns>
        public static List<string> ExtractArgs(string argsString)
        {
            return Regex.Matches(argsString, @"[\""].+?[\""]|[^ ]+")
                .Cast<Match>()
                .Select(m => m.Value.Replace("\"", "")).ToList();
        }
    }
}
