namespace CodeBase.Data
{
    public interface ICompetitor
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }

        public string AgeGroup { get; set; }
    }
}