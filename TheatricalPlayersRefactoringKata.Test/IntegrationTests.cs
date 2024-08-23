using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheatricalPlayersRefactoringKata.Presentation.Controllers;
using Xunit;

namespace TheatricalPlayersRefactoringKata.Tests
{
    public class IntegrationTests
    {
        [Fact]
        public void TestFullIntegration()
        {
            var plays = new Dictionary<string, Play>
                {
                    { "hamlet", new Play("Hamlet", 4024, "tragedy") },
                    { "as-like", new Play("As You Like It", 2670, "comedy") },
                    { "othello", new Play("Othello", 3560, "tragedy") }
                };

            var invoice = new Invoice(
                "BigCo",
                new List<Performance>
                {
                        new Performance("hamlet", 55),
                        new Performance("as-like", 35),
                        new Performance("othello", 40)
                }
            );

            var statementPrinter = new StatementPrinter();
            var result = statementPrinter.Print(invoice, plays);

            string expectedOutput = "Statement for BigCo\n" +
                                    "  Hamlet: $650.00 (55 seats)\n" +
                                    "  As You Like It: $547.00 (35 seats)\n" +
                                    "  Othello: $456.00 (40 seats)\n" +
                                    "Amount owed is $1,653.00\n" +
                                    "You earned 47 credits\n";

            Assert.Equal(expectedOutput, result);
        }
    }
}
