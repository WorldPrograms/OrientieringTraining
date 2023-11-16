using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Infrastructure.Services
{
    public class CompetitorAdderPanelServise: ICompetitorAdderPanelServise
    {
        private CompetitorPanel _panel;
        private ISlideServise _slideServise;

        public CompetitorAdderPanelServise(ISlideServise slideServise)
        {
            _slideServise = slideServise;
        }

        public void ShowPanel()
        {
            Debug.Log("wd");
            _panel = _slideServise.InstantiateSlide(SlidesConstants.AD_COMPETITOR_PANEL).GetComponent<CompetitorPanel>();
        }

        public void HidePanel()
        {
            _panel.Delite();
        }
    }
}
