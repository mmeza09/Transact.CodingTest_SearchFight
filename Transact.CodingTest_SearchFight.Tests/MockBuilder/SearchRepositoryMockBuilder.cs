using Moq;
using System;
using System.Threading.Tasks;
using Transact.CodingTest_SearchFight.ApplicationCore.Interfaces;

namespace Transact.CodingTest_SearchFight.Tests.MockBuilder
{
    class SearchRepositoryMockBuilder
    {
        private readonly Mock<ISearchRepository> _searchRepository;

        public SearchRepositoryMockBuilder()
        {
            _searchRepository = new Mock<ISearchRepository>();
        }

        public SearchRepositoryMockBuilder WithValidLongData()
        {
            _searchRepository.Setup(x => x.GetResultAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(long.Parse(new Random().Next(1, 100).ToString())));
            return this;
        }

        public SearchRepositoryMockBuilder WithNoData()
        {
            _searchRepository.Setup(x => x.GetResultAsync(It.Is<string>(y => y == "no results query")))
                .Returns(Task.FromResult(long.Parse(0.ToString())));
            return this;
        }

        public SearchRepositoryMockBuilder WithEngineName(string name)
        {
            _searchRepository.Setup(x => x.Name)
                .Returns(name);
            return this;
        }

        public ISearchRepository Build()
        {
            return _searchRepository.Object;
        }
    }
}
