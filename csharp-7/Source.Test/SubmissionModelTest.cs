using Codenation.Challenge;
using Codenation.Challenge.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Source.Test
{
    public sealed class SubmissionModelTest : ModelBaseTest
    {
        public SubmissionModelTest()
            : base(new CodenationContext())
        {
            Model = "Codenation.Challenge.Models.Submission";
            Table = "submission";
        }

        [Fact]
        public void Should_Has_Table()
        {
            AssertTable();
        }

    }
}
