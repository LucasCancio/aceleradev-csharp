using Codenation.Challenge;
using Codenation.Challenge.Models;
using Xunit;

namespace Source.Test
{
    public sealed class UserModelTest : ModelBaseTest
    {
        public UserModelTest()
            : base(new CodenationContext())
        {
            Model = "Codenation.Challenge.Models.User";
            Table = "user";
        }

        [Fact]
        public void Should_Has_Table()
        {
            AssertTable();
        }

    }
}
