using System.Collections.Generic;

namespace Transact.CodingTest_SearchFight.ApplicationCore.Models
{
    /// <summary>
    /// Class that contains all search results
    /// </summary>
    public class SearchReport
    {
        /// <summary>
        /// All results by term searched in the existing search engines
        /// </summary>
        public List<Search> SearchResults { get; set; }

        /// <summary>
        /// List of winners by search engine
        /// </summary>
        public List<Search> SearchWinners { get; set; }

        /// <summary>
        /// Term search total winner
        /// </summary>
        public string SearchTotalWinner { get; set; }
    }
}
