using CodeBase.Data;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.CompetitorsServise;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateCompetitorsController : MonoBehaviour
{

    private ICompetitorsServise _competitorsServise;
    [SerializeField] private InputField _input;
    void Awake()
    {
        _competitorsServise = AllServices.Container.Single<ICompetitorsServise>();
    }

    public void OnTestButtonDown()
    {
        Competitor newCompetitor = new Competitor(firstName: _input.text);
        _competitorsServise.GameCompetitors.AdCompetitor(newCompetitor);
    }
}
