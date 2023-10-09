namespace CodeBase.Data
{
    public class Competitor: ICompetitor
    {
        public Competitor(string firstName, string lastName,
            AgeGroup group = AgeGroup.OG, string customGroupName = null)
        {
            FirstName = firstName;
            LastName = lastName;
            AgeGroup = group;
            CustomGroupName = customGroupName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public AgeGroup AgeGroup { get; set; }
        public string CustomGroupName { get; set; }
    }
}
