namespace CodeBase.Data
{
    public interface ICompetitor
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public AgeGroup AgeGroup { get; set; }
        public string CustomGroupName { get; set; }
    }
}