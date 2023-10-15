using CodeBase.Data;
using CodeBase.Infrastructure.Services;

namespace CodeBase.Infrastructure.Services.CompetitorsServise
{
    public interface ICompetitorsServise: IService
    {
        public GameEvents GameEvents { get; set; }
        public GameCompetitors GameCompetitors { get; set; }
    }
}