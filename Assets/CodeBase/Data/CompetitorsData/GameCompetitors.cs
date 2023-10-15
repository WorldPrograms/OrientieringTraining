using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Data
{
    public class GameCompetitors
    {
        public List<Competitor> AllCompetitors { get; set; } = new List<Competitor>();

        public void AdCompetitor(Competitor competitor)
        {
            AllCompetitors.Add(competitor);
            Debug.Log(competitor);
        }
    }
}