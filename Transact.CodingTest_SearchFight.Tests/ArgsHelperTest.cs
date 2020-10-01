using Transact.CodingTest_SearchFight.ConsoleUI.Helper;
using Xunit;

namespace Transact.CodingTest_SearchFight.Tests
{
    public class ArgsHelperTest
    {
        [Fact]
        public void ExtractArgs_IncludeQuotedArg()
        {
            // Arrange
            string stringArgs = ".net java \"java script\"";
            // Act
            var args = ArgsHelper.ExtractArgs(stringArgs);
            // Assert
            Assert.Equal(3, args.Count);
        }
    }
}
