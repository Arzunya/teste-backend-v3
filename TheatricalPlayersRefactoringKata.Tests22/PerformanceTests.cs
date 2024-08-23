using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheatricalPlayersRefactoringKata.Tests
{
    public class PerformanceTests
    {
        [Fact]
        public void TestPerformanceCreation()
        {
            var performance = new Performance("hamlet", 55);
            Assert.Equal("hamlet", performance.PlayId);
            Assert.Equal(55, performance.Audience);
        }
    }
}
