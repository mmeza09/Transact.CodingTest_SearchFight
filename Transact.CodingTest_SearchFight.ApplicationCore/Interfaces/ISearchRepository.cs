using System.Threading.Tasks;

namespace Transact.CodingTest_SearchFight.ApplicationCore.Interfaces
{
    /// <summary>
    /// Search engine repository interface
    /// </summary>
    public interface ISearchRepository
    {
        /// <summary>
        /// Get search engine name
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Get search engine total results
        /// </summary>
        /// <param name="term">word to search</param>
        /// <returns><see cref="long"/>total results</returns>
        Task<long> GetResultAsync(string term);
    }
}
