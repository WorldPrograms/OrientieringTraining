using System.Collections;
using System.Collections.Generic;
using CodeBase.Data;
using CodeBase.Infrastructure.AssetManagement;
using UnityEngine;

public class AgeGroupsAdder : IAgeGroupsAdder
{
    private readonly IAssetProvider _assets;
    private List<AgeGroupController> _ageGroupControllers = new List<AgeGroupController>();

    public AgeGroupsAdder(IAssetProvider assets)
    {
        _assets = assets;
    }

    public void ClearGroups()
    {
        foreach (var controller in _ageGroupControllers)
        {
            controller.Delite();
        }
        _ageGroupControllers.Clear();
    }

    public void InstantiateGroup(Group competitorsAgeGroup, Transform at)
    {
        AgeGroupController ageGroupController = _assets.Instantiate(AssetPath.PathGroup, at).GetComponent<AgeGroupController>();
        GroupNameSet(competitorsAgeGroup, ageGroupController);
        InstanceCompetitors(competitorsAgeGroup, ageGroupController);
        _ageGroupControllers.Add(ageGroupController);
    }

    private void GroupNameSet(Group competitorsAgeGroup, AgeGroupController ageGroupController)
    {
        string charOfGender = string.Empty;
        charOfGender = GetCharOfGender(competitorsAgeGroup, charOfGender);

        string nameOfGroup;
        nameOfGroup = GetNameWithGender(competitorsAgeGroup, charOfGender);

        ageGroupController.NameGroup.text = nameOfGroup;
    }

    private string GetNameWithGender(Group competitorsAgeGroup, string charOfGender)
    {
        string nameOfGroup;
        if (competitorsAgeGroup.AgeGroup != AgeGroupExample.OG.ToString())
            nameOfGroup = charOfGender + competitorsAgeGroup.AgeGroup.Remove(0, 1);
        else
            nameOfGroup = competitorsAgeGroup.AgeGroup;
        return nameOfGroup;
    }

    private string GetCharOfGender(Group competitorsAgeGroup, string charOfGender)
    {
        if (competitorsAgeGroup.Gender == Gender.Male)
            charOfGender = "М";
        else if (competitorsAgeGroup.Gender == Gender.Female)
            charOfGender = "Ж";
        return charOfGender;
    }

    private void InstanceCompetitors(Group competitorsAgeGroup, AgeGroupController ageGroupController)
    {
        foreach (var competitor in competitorsAgeGroup.CompetitorsInGroup)
        {
            ageGroupController.InitialCompetitor(competitor);
        }
    }
}
