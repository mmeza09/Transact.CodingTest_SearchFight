using System.Collections.Generic;
using System.Threading.Tasks;
using Transact.CodingTest_SearchFight.ApplicationCore.Models;

namespace Transact.CodingTest_SearchFight.ApplicationCore.Interfaces
{
    /// <summary>
    /// Report service interface
    /// </summary>
    public interface IReportService
    {
        /// <summary>
        /// Get search fight result
        /// </summary>
        /// <param name="args"></param>
        /// <returns><see cref="SearchReport"/></returns>
        Task<SearchReport> ExecuteSearchFightAsync(List<string> args);
    }
}
