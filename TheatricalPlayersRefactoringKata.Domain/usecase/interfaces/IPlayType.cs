using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheatricalPlayersRefactoringKata.Domain.usecase.interfaces
{
    public interface IPlayType
    {
        decimal CalculateAmount(Play play, Performance perf);
        decimal CalculateVolumeCredits(Play play, Performance perf);
    }
}

