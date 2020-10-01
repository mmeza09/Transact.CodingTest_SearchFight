using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Transact.CodingTest_SearchFight.ApplicationCore.Interfaces;
using Transact.CodingTest_SearchFight.Infraestructure.Models.Bing;
using Transact.CodingTest_SearchFight.Infraestructure.Models.Config;

namespace Transact.CodingTest_SearchFight.Infraestructure.Repository
{
    /// <summary>
    /// <see cref="ISearchRepository"/> implementation for Bing search
    /// </summary>
    public class BingSearchRespository : ISearchRepository
    {
        /// <summary>
        /// read only Bing config 
        /// </summary>
        private readonly BingConfig _bingConfig;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="bingConfig">Bing config information</param>
        public BingSearchRespository(IOptions<BingConfig> bingConfig)
        {
            _bingConfig = bingConfig.Value;
        }

        /// <summary>
        /// Bing display name
        /// </summary>
        public string Name => _bingConfig.Name;

        /// <summary>
        /// Get total results from Bing search
        /// </summary>
        /// <param name="term">Word to search</param>
        /// <returns>(<see cref="long"/>) total results</returns>
        public async Task<long> GetResultAsync(string term)
        {
            if (term is null || term == string.Empty)
            {
                throw new ArgumentException($"The object {nameof(term)} is null or empty.");
            }
            var baseAddress = $"{_bingConfig.Url}?q={Uri.EscapeDataString(term)}";
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _bingConfig.ApiKey);
                var response = await client.GetAsync(baseAddress);
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Unable to process request. Please try again.");
                var stringResponse = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                try
                {
                    var result = JsonSerializer.Deserialize<BingResponse>(stringResponse, options);
                    return result.WebPages.TotalEstimatedMatches;
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
