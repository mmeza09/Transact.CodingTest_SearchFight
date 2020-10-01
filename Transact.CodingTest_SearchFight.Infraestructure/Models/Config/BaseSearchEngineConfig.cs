namespace Transact.CodingTest_SearchFight.Infraestructure.Models.Config
{
    /// <summary>
    /// Base search engine config class
    /// </summary>
    public class BaseSearchEngineConfig
    {
        /// <summary>
        /// Search engine name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Search engine api key
        /// </summary>
        public string ApiKey { get; set; }
        /// <summary>
        /// Search engine url
        /// </summary>
        public string Url { get; set; }
    }
}
