namespace CodeBase.Infrastructure.Services
{
    public interface ICompetitorAdderPanelServise: IService
    {
        public void InstantiatePanel();
        public void ShowPanel();
        public void HidePanel();
    }
}