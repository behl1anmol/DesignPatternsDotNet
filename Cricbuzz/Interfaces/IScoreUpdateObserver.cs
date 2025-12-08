using Cricbuzz.Utils;

namespace Cricbuzz.Interfaces;

public interface IScoreUpdateObserver
{
    void UpdateScore(IPlayer playedBy, IPlayer bowledBy, RunType runType);
}