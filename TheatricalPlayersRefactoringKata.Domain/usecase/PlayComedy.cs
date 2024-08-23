using TheatricalPlayersRefactoringKata.Domain.usecase.interfaces;

namespace TheatricalPlayersRefactoringKata.Domain.usecase
{
    public class PlayComedy : IPlayType
    {
        public decimal CalculateAmount(Play play, Performance perf)
        {
            var lines = play.Lines;
            if (lines < 1000) lines = 1000;
            if (lines > 4000) lines = 4000;
            var baseAmount = (lines / 10m); 

            var thisAmount = baseAmount + 3m * perf.Audience;

            if (perf.Audience > 20)
            {
                thisAmount += 100m + 5m * (perf.Audience - 20);
            }

            return thisAmount;
        }

        public decimal CalculateVolumeCredits(Play play, Performance perf)
        {
            decimal credits = Math.Max(perf.Audience - 30, 0);
            credits += Math.Floor((decimal)perf.Audience / 5);
            return credits;
        }

    }
}
