using CodeBase.Infrastructure.Services;
using UnityEngine;

public class ButtonAdNewCompetitor : MonoBehaviour
{
    public void OpenPanelCompetitor()
    {
        AllServices.Container.Single<ICompetitorAdderPanelServise>().ShowPanel();
    }
}
