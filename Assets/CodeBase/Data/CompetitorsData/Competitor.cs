namespace CodeBase.Data
{
    public class Competitor: ICompetitor
    {
        public Competitor(string firstName, Gender gender, string group, string lastName = null)
        {
            FirstName = firstName;
            LastName = lastName;
            AgeGroup = group;
            Gender = gender;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }

        public string AgeGroup { get; set; }
    }
}
