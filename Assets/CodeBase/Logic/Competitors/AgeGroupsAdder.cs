using System.Collections;
using System.Collections.Generic;
using CodeBase.Data;
using UnityEngine;

public class AgeGroupsAdder : MonoBehaviour
{
    [SerializeField] private Transform _groupsParent;
    [SerializeField] private AgeGroupController _groupPrefab;
    public List<AgeGroupController> ageGroupControllers = new List<AgeGroupController>();

    public void InstantiateGroup(Group competitorsAgeGroup)
    {
        AgeGroupController ageGroupController = Instantiate(_groupPrefab, _groupsParent);
        GroupNameSet(competitorsAgeGroup, ageGroupController);
        InstanceCompetitors(competitorsAgeGroup, ageGroupController);
        ageGroupControllers.Add(ageGroupController);
        Debug.Log($"{competitorsAgeGroup.AgeGroup} created");
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
            nameOfGroup = charOfGender + competitorsAgeGroup.AgeGroup.Remove(0,1);
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
