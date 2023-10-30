using CodeBase.Data;
using UnityEngine;
using UnityEngine.UI;

public class AgeGroupController : MonoBehaviour
{
    public Text NameGroup;
    [SerializeField] private Transform _competitorsParent;
    [SerializeField] private CompetitorFieldController _competitorPrefab;
    private int _lastNumber = 1;

    public void InitialCompetitor(ICompetitor competitor)
    {
        CompetitorFieldController newCompetitorField = Instantiate(_competitorPrefab, _competitorsParent);
        newCompetitorField.CompetitorNameText.text = competitor.LastName ?? "" + competitor.FirstName;
        newCompetitorField.CompetitorNumber.text = _lastNumber.ToString();
        _lastNumber++;
    }
}
