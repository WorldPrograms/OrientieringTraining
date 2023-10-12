using CodeBase.Data;

namespace CodeBase.Infrastructure.Services.CompetitorsServise
{
    public class CompetitorsServise: ICompetitorsServise
    {
        public CompetitorsServise()
        {
            GameEvents = new GameEvents();
            GameCompetitors = new GameCompetitors();
        }

        public GameEvents GameEvents;
        public GameCompetitors GameCompetitors;
	}
}

