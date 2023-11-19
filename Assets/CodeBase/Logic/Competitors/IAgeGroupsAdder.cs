using CodeBase.Data;
using UnityEngine;

public interface IAgeGroupsAdder
{
    void InstantiateGroup(Group competitorsAgeGroup, Transform at);

    public void ClearGroups();
}