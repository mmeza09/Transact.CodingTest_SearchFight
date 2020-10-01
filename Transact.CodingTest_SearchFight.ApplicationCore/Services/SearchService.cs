using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Transact.CodingTest_SearchFight.ApplicationCore.Interfaces;
using Transact.CodingTest_SearchFight.ApplicationCore.Models;

namespace Transact.CodingTest_SearchFight.ApplicationCore.Services
{
    /// <summary>
    /// <see cref="ISearchService"/> implementation. Service to get search results
    /// </summary>
    public class SearchService : ISearchService
    {
        private readonly IEnumerable<ISearchRepository> _searchRepositories;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="searchRepositories"></param>
        public SearchService(IEnumerable<ISearchRepository> searchRepositories)
        {
            _searchRepositories = searchRepositories;
        }
        /// <summary>
        /// Get search results of all search engines
        /// </summary>
        /// <param name="terms"></param>
        /// <returns></returns>
        /// <exception cref="Argument"
        public async Task<List<Search>> GetResultsAsync(List<string> terms)
        {
            if (terms is null || terms.Count == 0)
            {
                throw new ArgumentException($"The object {nameof(terms)} is null or empty.");
            }
            var list = new List<Search>();
            foreach (var term in terms)
            {
                foreach (var repository in _searchRepositories)
                {
                    var result = new Search()
                    {
                        SearchEngine = repository.Name,
                        Term = term,
                        TotalResults = await repository.GetResultAsync(term)
                    };
                    list.Add(result);
                }
            }
            return list;
        }
    }
}
