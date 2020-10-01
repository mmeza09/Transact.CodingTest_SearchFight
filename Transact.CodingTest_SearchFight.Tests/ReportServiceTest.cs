using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Transact.CodingTest_SearchFight.ApplicationCore.Interfaces;
using Transact.CodingTest_SearchFight.ApplicationCore.Services;
using Transact.CodingTest_SearchFight.Tests.MockBuilder;
using Xunit;

namespace Transact.CodingTest_SearchFight.Tests
{
    public class ReportServiceTest
    {
        private readonly SearchRepositoryMockBuilder _googleSearchRepositoryMockBuilder;
        private readonly SearchRepositoryMockBuilder _bingSearchRepositoryMockBuilder;
        private readonly ReportService _reportService;
        public ReportServiceTest()
        {
            _googleSearchRepositoryMockBuilder = new SearchRepositoryMockBuilder();
            _bingSearchRepositoryMockBuilder = new SearchRepositoryMockBuilder();
            IEnumerable<ISearchRepository> repositories = BuildIEnumerableSearchRepositories();
            var searchService = new SearchService(repositories);
            var winnerservice = new WinnerService();
            _reportService = new ReportService(searchService, winnerservice);
        }

        private List<ISearchRepository> BuildIEnumerableSearchRepositories()
        {
            return new List<ISearchRepository>
            {
                _googleSearchRepositoryMockBuilder.WithEngineName("Google").Build(),
                _bingSearchRepositoryMockBuilder.WithEngineName("Bing").Build()
            };
        }


        [Fact]
        public async Task GetResultsAsync_NullArg_ReturnArgumentException()
        {
            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _reportService.ExecuteSearchFightAsync(null));
        }

        [Fact]
        public async Task GetResultsAsync_EmptyArg_ReturnArgumentException()
        {
            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _reportService.ExecuteSearchFightAsync(new List<string>()));
        }

        [Fact]
        public async Task GetResultsAsync_ValidTerm_ReturnValidReportData()
        {
            //Arrange
            _googleSearchRepositoryMockBuilder.WithValidLongData();
            _bingSearchRepositoryMockBuilder.WithValidLongData();

            //Act
            var report = await _reportService.ExecuteSearchFightAsync(new List<string> { ".NET", "Java" });

            // Assert
            Assert.NotNull(report);
            Assert.Equal(4, report.SearchResults.Count);
            Assert.Equal(2, report.SearchWinners.Count);
            Assert.NotNull(report.SearchTotalWinner);
            Assert.NotEmpty(report.SearchTotalWinner);
        }
    }
}
