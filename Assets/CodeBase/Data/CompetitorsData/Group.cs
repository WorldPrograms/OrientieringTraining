﻿using System.Collections.Generic;

namespace CodeBase.Data
{
    public class Group
    {
        public Group(string group, Gender gender = Gender.None)
        {
            AgeGroup = group;
            Gender = gender;
            CompetitorsInGroup = new List<ICompetitor>();
        }

        public List<ICompetitor> CompetitorsInGroup;
        public string AgeGroup;
        public Gender Gender;
    }
}
