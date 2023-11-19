using System.Collections;
using System.Collections.Generic;
using CodeBase.Data;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.CompetitorsServise;
using UnityEngine;

public class ProtocolCreater : MonoBehaviour
{
    [SerializeField] private Transform _parent;
    private ICompetitorsServise _competitorsServise;
    private IAgeGroupsAdder _ageGroupsAdder;

    private void Awake()
    {
        _competitorsServise = AllServices.Container.Single<ICompetitorsServise>();
        _ageGroupsAdder = _competitorsServise.AgeGroupsAdder;
    }

    private void Start()
    {
        _competitorsServise.GameCompetitors.AdCompetitor(new Competitor("Mark", gender: Gender.Male, group: AgeGroupExample.OG.ToString(), lastName: "Reeeeee"));
        _competitorsServise.GameCompetitors.AdCompetitor(new Competitor("Ivananina", gender: Gender.Female, AgeGroupExample.OG.ToString()));

        _competitorsServise.GameCompetitors.AdCompetitor(new Competitor("Masha", gender: Gender.Female, group: AgeGroupExample.G10.ToString()));
        _competitorsServise.GameCompetitors.AdCompetitor(new Competitor("Misha", gender: Gender.Male, group: AgeGroupExample.G10.ToString()));
        _competitorsServise.GameCompetitors.AdCompetitor(new Competitor("???????", gender: Gender.Male, group: AgeGroupExample.G16.ToString()));
        _competitorsServise.GameCompetitors.AdCompetitor(new Competitor("Savostina", gender: Gender.Male, group: AgeGroupExample.G16.ToString()));
        _competitorsServise.GameCompetitors.AdCompetitor(new Competitor("???????", lastName: "??????", gender: Gender.Male, group: AgeGroupExample.G16.ToString()));

        _competitorsServise.GameCompetitors.AdCompetitor(new Competitor("Svetka", gender: Gender.Female, group: "GChemp"));
        _competitorsServise.GameCompetitors.AdCompetitor(new Competitor("Ania", gender: Gender.Female, group: "GChemp"));
        CreateProtocol();
    }

    public void CreateProtocol()
    {
        _ageGroupsAdder.ClearGroups();

        

        foreach (var group in _competitorsServise.GameCompetitors.AllGroups)
        {
            _ageGroupsAdder.InstantiateGroup(group, _parent);
        }
    }
}
