using Codenation.Challenge;
using Codenation.Challenge.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Source.Test
{
    public sealed class CandidateModelTest : ModelBaseTest
    {
        public CandidateModelTest()
            : base(new CodenationContext())
        {
            Model = "Codenation.Challenge.Models.Candidate";
            Table = "candidate";
        }

        [Fact]
        public void Should_Has_Table()
        {
            AssertTable();
        }

    }
}
