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
    [SerializeField] private AgeGroupsAdder _ageGroupsAdder;

    void Awake()
    {
        _competitorsServise = AllServices.Container.Single<ICompetitorsServise>();
    }

    private void Start()
    {
        _competitorsServise.GameCompetitors.AdCompetitor(new Competitor("Mark", gender: Gender.Male, group: AgeGroupExample.OG.ToString()));
        _competitorsServise.GameCompetitors.AdCompetitor(new Competitor("Ivan",gender: Gender.Male, AgeGroupExample.OG.ToString()));

        _competitorsServise.GameCompetitors.AdCompetitor(new Competitor("Masha", gender: Gender.Female, group: AgeGroupExample.G10.ToString()));
        _competitorsServise.GameCompetitors.AdCompetitor(new Competitor("Misha", gender: Gender.Male, group: AgeGroupExample.G10.ToString()));
        _competitorsServise.GameCompetitors.AdCompetitor(new Competitor("Кабачок", gender: Gender.Male, group: AgeGroupExample.G16.ToString()));
        _competitorsServise.GameCompetitors.AdCompetitor(new Competitor("Savostina", gender: Gender.Male, group: AgeGroupExample.G16.ToString()));
        _competitorsServise.GameCompetitors.AdCompetitor(new Competitor("Ярослав",lastName:"Грязин", gender: Gender.Male, group: AgeGroupExample.G16.ToString()));

        _competitorsServise.GameCompetitors.AdCompetitor(new Competitor("Svetka", gender: Gender.Female, group: "GChemp"));
        _competitorsServise.GameCompetitors.AdCompetitor(new Competitor("Ania", gender: Gender.Female, group: "GChemp"));
    }

    public void OnTestButtonDown()
    {
        foreach (var group in _competitorsServise.GameCompetitors.AllGroups)
        {
            _ageGroupsAdder.InstantiateGroup(group);
        }
    }
}
