using System.Collections.Generic;
using Transact.CodingTest_SearchFight.ApplicationCore.Models;

namespace Transact.CodingTest_SearchFight.ApplicationCore.Interfaces
{
    /// <summary>
    /// Winner service interface
    /// </summary>
    public interface IWinnerService
    {
        /// Get winners by search engine.
        List<Search> GetWinnerBySearchEngine(List<Search> searchData);

        /// Get total search winner.
        string GetTotalWinner(List<Search> searchData);
    }
}
