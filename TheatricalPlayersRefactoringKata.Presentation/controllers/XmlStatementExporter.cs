using System;
using System.Collections.Generic;
using System.Xml.Linq;
using TheatricalPlayersRefactoringKata.Domain.usecase;
using TheatricalPlayersRefactoringKata.Domain.usecase.interfaces;

namespace TheatricalPlayersRefactoringKata.Presentation.Controllers
{
    public class XmlStatementExporter
    {
        public string Export(Invoice invoice, Dictionary<string, Play> plays)
        {
            decimal totalAmount = 0;
            decimal totalVolumeCredits = 0;

            var statement = new XElement("Statement",
                new XAttribute(XNamespace.Xmlns + "xsi", "http://www.w3.org/2001/XMLSchema-instance"),
                new XAttribute(XNamespace.Xmlns + "xsd", "http://www.w3.org/2001/XMLSchema"),
                new XElement("Customer", invoice.Customer),
                new XElement("Items")
            );

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
                var thisCredits = playType.CalculateVolumeCredits(play, perf);

                totalAmount += thisAmount;
                totalVolumeCredits += thisCredits;

                statement.Element("Items").Add(new XElement("Item",
                    new XElement("AmountOwed", thisAmount),
                    new XElement("EarnedCredits", thisCredits),
                    new XElement("Seats", perf.Audience)
                ));
            }

            statement.Add(new XElement("AmountOwed", totalAmount));
            statement.Add(new XElement("EarnedCredits", totalVolumeCredits));

            var xmlString = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n" + statement.ToString();

            return xmlString;
        }
    }
}
