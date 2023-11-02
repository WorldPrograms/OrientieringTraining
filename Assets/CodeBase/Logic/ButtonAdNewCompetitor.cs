using CodeBase.Infrastructure.Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAdNewCompetitor : MonoBehaviour
{
    public void OpenPanelCompetitor()
    {
        AllServices.Container.Single<ICompetitorAdderPanelServise>().ShowPanel();
    }
}
