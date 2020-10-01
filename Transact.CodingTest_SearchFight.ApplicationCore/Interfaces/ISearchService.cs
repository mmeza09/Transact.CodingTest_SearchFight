using System.Collections.Generic;
using System.Threading.Tasks;
using Transact.CodingTest_SearchFight.ApplicationCore.Models;

namespace Transact.CodingTest_SearchFight.ApplicationCore.Interfaces
{
    /// <summary>
    /// Search service interface
    /// </summary>
    public interface ISearchService
    {
        /// <summary>
        /// Get search results
        /// </summary>
        /// <param name="terms"></param>
        /// <returns>List of <see cref="Search"/></returns>
        Task<List<Search>> GetResultsAsync(List<string> terms);
    }
}
