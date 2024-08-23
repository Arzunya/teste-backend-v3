using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TheatricalPlayersRefactoringKata.Tests
{
    public class PlayTests
    {
        [Fact]
        public void TestPlayCreation()
        {
            var play = new Play("Hamlet", 3500, "tragedy");
            Assert.Equal("Hamlet", play.Name);
            Assert.Equal(3500, play.Lines);
            Assert.Equal("tragedy", play.Type);
        }
    }
}
