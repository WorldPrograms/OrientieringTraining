using System.Collections;
using System.Collections.Generic;
using CodeBase.Data;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.CompetitorsServise;
using UnityEngine;

namespace CodeBase.Logic
{
    public class CompetitorAdder : MonoBehaviour
    {
        [SerializeField] private CompetitorPanel _competitorPanel;
        private ICompetitorsServise _competitorsServise;

        private void Awake()
        {
            _competitorPanel = GetComponent<CompetitorPanel>();
            _competitorsServise = AllServices.Container.Single<ICompetitorsServise>();
        }

        public void OnCreateFinish()
        {
            string firstName = _competitorPanel.FirstNameField.text;
            string secondName = null;
            if (_competitorPanel.LastNameField.text != string.Empty)
                secondName = _competitorPanel.LastNameField.text;

            Gender gender = Gender.None;
            if (_competitorPanel.GenderDropdown.itemText.text == Gender.Male.ToString())
                gender = Gender.Male;
            else if (_competitorPanel.GenderDropdown.itemText.text == Gender.Female.ToString())
                gender = Gender.Female;
            string group = _competitorPanel.AgeGroupDropdown.itemText.text;


            Competitor competitor = new Competitor(firstName, gender, group, secondName);
            _competitorsServise.GameCompetitors.AdCompetitor(competitor);
            _competitorPanel.Hide();
        }
    }

}
