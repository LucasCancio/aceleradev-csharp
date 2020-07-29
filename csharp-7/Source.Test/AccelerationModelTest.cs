using Codenation.Challenge;
using Codenation.Challenge.Models;
using Xunit;

namespace Source.Test
{
    public sealed class AccelerationModelTest : ModelBaseTest
    {
        public AccelerationModelTest()
            : base(new CodenationContext())
        {
            Model = "Codenation.Challenge.Models.Acceleration";
            Table = "acceleration";
        }

        [Fact]
        public void Should_Has_Table()
        {
            AssertTable();
        }

        //Should_Has_Foreing_Key(fieldName: "challenge_id", relatedTable: "challenge", isNullable: False, relatedKey: "id")

    }
}
