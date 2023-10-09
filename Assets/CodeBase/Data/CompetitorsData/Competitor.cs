namespace CodeBase.Data
{
    public class Competitor: ICompetitor
    {
        public Competitor(string firstName, string lastName, Gender gender,
            AgeGroup group = AgeGroup.OG, string customGroupName = null)
        {
            FirstName = firstName;
            LastName = lastName;
            AgeGroup = group;
            CustomGroupName = customGroupName;
            Gender = gender;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }

        public AgeGroup AgeGroup { get; set; }
        public string CustomGroupName { get; set; }
    }
}
