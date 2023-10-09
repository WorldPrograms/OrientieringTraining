using System.Collections.Generic;

namespace CodeBase.Data
{
    public class Group
    {
        public Group(AgeGroup group = AgeGroup.OG, Gender gender = Gender.None, string customGroupName = null)
        {
            AgeGroup = group;
            CustomGroupName = customGroupName;
            Gender = gender;
            CompetitorsInGroup = new List<Competitor>();
        }

        public List<Competitor> CompetitorsInGroup;
        public AgeGroup AgeGroup;
        public string CustomGroupName;
        public Gender Gender;
    }
}
