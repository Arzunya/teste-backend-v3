using System;
using System.Collections.Generic;
using System.Globalization;
using TheatricalPlayersRefactoringKata.Domain.usecase.interfaces;
using TheatricalPlayersRefactoringKata.Domain.usecase;

namespace TheatricalPlayersRefactoringKata.Presentation.Controllers
{
    public class StatementPrinter
    {
        public string Print(Invoice invoice, Dictionary<string, Play> plays)
        {
            decimal totalAmount = 0;
            decimal volumeCredits = 0;
            var result = string.Format("Statement for {0}\n", invoice.Customer);
            CultureInfo cultureInfo = new CultureInfo("en-US");

            foreach (var perf in invoice.Performances)
            {
                var play = plays[perf.PlayId];
                IPlayType playType = play.Type switch
                {
                    "comedy" => new PlayComedy(),
                    "tragedy" => new PlayTragedy(),
                    "history" => new PlayHistory(),
                    _ => throw new Exception("unknown type: " + play.Type)
                };

                var thisAmount = playType.CalculateAmount(play, perf);
                volumeCredits += playType.CalculateVolumeCredits(play, perf);

                result += String.Format(cultureInfo, "  {0}: {1:C} ({2} seats)\n", play.Name, thisAmount, perf.Audience);
                totalAmount += thisAmount;
            }

            result += String.Format(cultureInfo, "Amount owed is {0:C}\n", totalAmount);
            result += String.Format("You earned {0} credits\n", volumeCredits);

            return result;
        }
    }
}
