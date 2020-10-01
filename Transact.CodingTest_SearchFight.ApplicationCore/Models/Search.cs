namespace Transact.CodingTest_SearchFight.ApplicationCore.Models
{
    /// <summary>
    /// Search result class
    /// </summary>
    public class Search
    {
        /// <summary>
        /// Search engine name
        /// </summary>
        public string SearchEngine { get; set; }

        /// <summary>
        /// Word searched
        /// </summary>
        public string Term { get; set; }

        /// <summary>
        /// Search total results 
        /// </summary>
        public long TotalResults { get; set; }
    }
}
