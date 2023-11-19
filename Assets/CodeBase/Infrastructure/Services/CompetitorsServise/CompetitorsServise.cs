using CodeBase.Data;

namespace CodeBase.Infrastructure.Services.CompetitorsServise
{
    public class CompetitorsServise: ICompetitorsServise
    {
        public CompetitorsServise(AgeGroupsAdder ageGroupsAdder)
        {
            GameEvents = new GameEvents();
            GameCompetitors = new GameCompetitors();
            AgeGroupsAdder = ageGroupsAdder;
        }

        public GameEvents GameEvents { get; set; }
        public GameCompetitors GameCompetitors { get; set; }
        public AgeGroupsAdder AgeGroupsAdder { get; set;}
	}
}

