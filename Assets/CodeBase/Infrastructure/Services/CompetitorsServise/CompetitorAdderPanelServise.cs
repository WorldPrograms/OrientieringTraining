using CodeBase.Logic;

namespace CodeBase.Infrastructure.Services
{
    public class CompetitorAdderPanelServise: ICompetitorAdderPanelServise
    {
        private CompetitorPanel _panel;

        public CompetitorAdderPanelServise(CompetitorPanel panel)
        {
            _panel = panel;
        }

        public void ShowPanel()
        {
            _panel.Show();
        }

        public void HidePanel()
        {
            _panel.Hide();
        }
    }
}
