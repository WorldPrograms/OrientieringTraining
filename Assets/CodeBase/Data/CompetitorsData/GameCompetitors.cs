using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Data
{
    public class GameCompetitors
    {
        //public List<Competitor> AllCompetitors { get; private set; } = new List<Competitor>();

        public List<Group> AllGroups { get; set; } = new List<Group>();

        public void AdCompetitor(Competitor competitor)
        {
            Group group = GetGroup(competitor.AgeGroup, competitor.Gender);
            if (group == null)
                group = new Group(
                    group: competitor.AgeGroup,
                    gender: competitor.Gender,
                    customGroupName: competitor.CustomGroupName
                    );

            group.CompetitorsInGroup.Add(competitor);
            Debug.Log(competitor);
        }

        private Group GetGroup(AgeGroup ageGroup, Gender gender)
        {
            foreach (var group in AllGroups)
            {
                if (group.AgeGroup == ageGroup && group.Gender == gender)
                    return group;
            }
            return null;
        }

        public List<Competitor> GetGroupCompetitor(AgeGroup ageGroup, string customName)
        {
            List<Competitor> competitors = new List<Competitor>();
            foreach (var competitor in AllCompetitors)
            {
                if (competitor.AgeGroup == ageGroup)
                    competitors.Add(competitor);
            }
            return competitors;
        }
    }
}