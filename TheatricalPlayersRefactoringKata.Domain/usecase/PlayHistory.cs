using TheatricalPlayersRefactoringKata.Domain.usecase.interfaces;

namespace TheatricalPlayersRefactoringKata.Domain.usecase
{
    public class PlayHistory : IPlayType
    {
        private readonly PlayComedy _playComedy;
        private readonly PlayTragedy _playTragedy;

        public PlayHistory()
        {
            _playComedy = new PlayComedy();
            _playTragedy = new PlayTragedy();
        }

        public decimal CalculateAmount(Play play, Performance perf)
        {
            decimal comedyAmount = _playComedy.CalculateAmount(play, perf);
            decimal tragedyAmount = _playTragedy.CalculateAmount(play, perf);
            return comedyAmount + tragedyAmount;
        }

        public decimal CalculateVolumeCredits(Play play, Performance perf)
        {
            return _playTragedy.CalculateVolumeCredits(play, perf);
        }
    }
}
