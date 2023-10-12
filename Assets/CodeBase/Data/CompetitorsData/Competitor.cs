namespace CodeBase.Data
{
    public class Competitor: ICompetitor
    {
        public Competitor(string firstName, Gender gender, string lastName = null,
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
