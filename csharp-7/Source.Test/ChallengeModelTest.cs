using Codenation.Challenge;
using Codenation.Challenge.Models;
using Xunit;

namespace Source.Test
{
    public sealed class ChallengeModelTest : ModelBaseTest
    {
        public ChallengeModelTest()
            : base(new CodenationContext())
        {
            Model = "Codenation.Challenge.Models.Challenge";
            Table = "challenge";
        }

        [Fact]
        public void Should_Has_Table()
        {
            AssertTable();
        }

    }
}
