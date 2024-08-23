using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TheatricalPlayersRefactoringKata.Tests
{
    public class InvoiceTests
    {
        [Fact]
        public void TestInvoiceCreation()
        {
            var performances = new List<Performance>
            {
                new Performance("hamlet", 55),
                new Performance("as-like", 35)
            };
            var invoice = new Invoice("BigCo", performances);
            Assert.Equal("BigCo", invoice.Customer);
            Assert.Equal(2, invoice.Performances.Count);
        }
    }
}
