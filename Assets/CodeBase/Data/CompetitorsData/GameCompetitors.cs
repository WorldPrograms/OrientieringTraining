using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Data
{
    public class GameCompetitors
    {
        public List<Group> AllGroups { get; private set; } = new List<Group>();

        public void AdCompetitor(Competitor competitor)
        {
            Group group = GetGroup(competitor.AgeGroup, competitor.Gender);
            if (group == null)
            {
                group = new Group(
                    group: competitor.AgeGroup,
                    gender: competitor.Gender
                    );
                AllGroups.Add(group);
            }
                

            group.CompetitorsInGroup.Add(competitor);
            Debug.Log(competitor.FirstName);
        }

        private Group GetGroup(string ageGroup, Gender gender)
        {
            foreach (var group in AllGroups)
            {
                if (group.AgeGroup == ageGroup && group.Gender == gender)
                    return group;
            }
            return null;
        }
    }
}