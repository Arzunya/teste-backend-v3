using TheatricalPlayersRefactoringKata.Domain.usecase.interfaces;

namespace TheatricalPlayersRefactoringKata.Domain.usecase
{
    public class PlayTragedy : IPlayType
    {
        public decimal CalculateAmount(Play play, Performance perf)
        {
            var lines = play.Lines;
            if (lines < 1000) lines = 1000;
            if (lines > 4000) lines = 4000;
            var baseAmount = (lines / 10m); 

            var thisAmount = baseAmount;

            if (perf.Audience > 30)
            {
                thisAmount += 10m * (perf.Audience - 30);
            }

            return thisAmount;
        }

        public decimal CalculateVolumeCredits(Play play, Performance perf)
        {
            return Math.Max(perf.Audience - 30, 0);
        }

    }
}
