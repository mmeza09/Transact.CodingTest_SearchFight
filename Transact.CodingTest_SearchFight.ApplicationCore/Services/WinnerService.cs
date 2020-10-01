using System;
using System.Collections.Generic;
using System.Linq;
using Transact.CodingTest_SearchFight.ApplicationCore.Interfaces;
using Transact.CodingTest_SearchFight.ApplicationCore.Models;

namespace Transact.CodingTest_SearchFight.ApplicationCore.Services
{
    /// <summary>
    /// <see cref="IWinnerService"/> implementation. Service to get winner(s) data
    /// </summary>
    public class WinnerService : IWinnerService
    {
        /// <summary>
        /// Get total search winner 
        /// </summary>
        /// <param name="searchData"></param>
        /// <returns></returns>
        public string GetTotalWinner(List<Search> searchData)
        {
            if (searchData is null || searchData.Count() == 0)
            {
                throw new ArgumentException($"The object {nameof(searchData)} is null or empty.");
            }
            var groupedResults = searchData.GroupBy(x => x.Term)
                .Select(g => new { Id = g.Key, TotalResults = g.Sum(y => y.TotalResults) });

            var totalWinner = groupedResults.Aggregate((current, next) => current.TotalResults > next.TotalResults ? current : next);
            return totalWinner.Id;
        }

        /// <summary>
        /// Get winner by search engine
        /// </summary>
        /// <param name="searchData"></param>
        /// <returns>IEnumerable of <see cref="Search"/> objects</returns>
        public List<Search> GetWinnerBySearchEngine(List<Search> searchData)
        {
            if (searchData is null || searchData.Count() == 0)
            {
                throw new ArgumentException($"The object {nameof(searchData)} is null or empty.");
            }
            var winners = new List<Search>();
            var groupedData = searchData.GroupBy(data => data.SearchEngine).ToList();
            foreach (var data in groupedData)
            {
                winners.Add(data.Aggregate((current, next) => current.TotalResults > next.TotalResults ? current : next));
            }
            return winners;
        }
    }
}
