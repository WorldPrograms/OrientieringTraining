using System.Collections;
using System.Collections.Generic;
using CodeBase.Data;
using UnityEngine;

public class AgeGroupsAdder : MonoBehaviour
{
    [SerializeField] private Transform _groupsParent;
    [SerializeField] private AgeGroupController _groupPrefab;

    public void InstantiateGroup(Group competitorsAgeGroup)
    {
        AgeGroupController ageGroupController = Instantiate(_groupPrefab, _groupsParent);

        string nameOfGroup = competitorsAgeGroup.AgeGroup.ToString();
        if (competitorsAgeGroup.AgeGroup == AgeGroup.CustomGroup)
            nameOfGroup = competitorsAgeGroup.CustomGroupName;

        ageGroupController.NameGroup.text = nameOfGroup;

        foreach (var item in collection)
        {

        }
    }
}
