using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Transact.CodingTest_SearchFight.ApplicationCore.Interfaces;
using Transact.CodingTest_SearchFight.Infraestructure.Models.Config;
using Transact.CodingTest_SearchFight.Infraestructure.Models.Google;

namespace Transact.CodingTest_SearchFight.Infraestructure.Repository
{
    /// <summary>
    /// <see cref="ISearchRepository"/> implementation for Google search
    /// </summary>
    public class GoogleSearchRepository : ISearchRepository
    {
        /// <summary>
        /// read only Google config 
        /// </summary>
        private readonly GoogleConfig _googleConfig;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="googleConfig">Google config information</param>
        public GoogleSearchRepository(IOptions<GoogleConfig> googleConfig)
        {
            _googleConfig = googleConfig.Value;
        }

        /// <summary>
        /// Google display name 
        /// </summary>
        public string Name => _googleConfig.Name;

        /// <summary>
        /// Get total results from Google search
        /// </summary>
        /// <param name="term">Word to search</param>
        /// <returns>(<see cref="long"/>) total results</returns>
        public async Task<long> GetResultAsync(string term)
        {
            if (term is null || term == string.Empty)
            {
                throw new ArgumentException($"The object {nameof(term)} is null or empty.");
            }
            var baseAddress = $"{_googleConfig.Url}?key={_googleConfig.ApiKey}&cx={_googleConfig.Cx}&q={Uri.EscapeDataString(term)}";
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                var response = await client.GetAsync(baseAddress);
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Unable to process request. Please try again.");

                var stringResponse = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                var result = JsonSerializer.Deserialize<GoogleResponse>(stringResponse, options);
                return long.Parse(result.SearchInformation.TotalResults);
            }
        }
    }
}
