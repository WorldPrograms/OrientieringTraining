using System.Collections.Generic;

namespace CodeBase.Data
{
    public class GameCompetitors
    {
        public List<Competitor> AllCompetitors { get; set; } = new List<Competitor>();

        public void AdNewCompetitor(string firstName, Gender gender, string lastName = null,
            AgeGroup group = AgeGroup.OG, string customGroupName = null)
        {
            Competitor newCompetitor = new Competitor(firstName, gender, lastName, group, customGroupName);
            AllCompetitors.Add(newCompetitor);
        }
    }
}