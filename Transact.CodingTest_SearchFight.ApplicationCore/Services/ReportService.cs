using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Transact.CodingTest_SearchFight.ApplicationCore.Interfaces;
using Transact.CodingTest_SearchFight.ApplicationCore.Models;

namespace Transact.CodingTest_SearchFight.ApplicationCore.Services
{
    /// <summary>
    /// <see cref="IReportService"/> implementation. Service to get search fight result
    /// </summary>
    public class ReportService : IReportService
    {
        private readonly ISearchService _searchService;
        private readonly IWinnerService _winnerService;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="searchService"></param>
        /// <param name="winnerService"></param>
        public ReportService(ISearchService searchService,
                             IWinnerService winnerService)
        {
            _searchService = searchService;
            _winnerService = winnerService;
        }
        /// <summary>
        /// Get search fight report
        /// </summary>
        /// <param name="args"></param>
        /// <returns><see cref="SearchReport"/></returns>
        public async Task<SearchReport> ExecuteSearchFightAsync(List<string> args)
        {
            if (args is null || args.Count == 0)
            {
                throw new ArgumentException($"No args provided.");
            }
            var report = new SearchReport
            {
                SearchResults = await _searchService.GetResultsAsync(args)
            };
            report.SearchWinners = _winnerService.GetWinnerBySearchEngine(report.SearchResults);
            report.SearchTotalWinner = _winnerService.GetTotalWinner(report.SearchWinners);
            return report;
        }
    }
}
