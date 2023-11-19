using CodeBase.Data;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Logic
{
    public class CompetitorPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;

        public InputField FirstNameField;
        public InputField LastNameField;
        public Dropdown AgeGroupDropdown;
        public Dropdown GenderDropdown;
        public InputField CustomGroupName;

        private void Start()
        {
            CreateDropdownGender();
            CreateDropdownAgeGroup();
        }

        public void Show()
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }

        public void Hide()
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }

        private void CreateDropdownGender()
        {
            GenderDropdown.ClearOptions();
            var optionList = new System.Collections.Generic.List<Dropdown.OptionData>()
            {
                new Dropdown.OptionData("Male"),
                new Dropdown.OptionData("Female"),
                new Dropdown.OptionData("None")
            };
            GenderDropdown.AddOptions(optionList);
        }

        private void CreateDropdownAgeGroup()
        {
            AgeGroupDropdown.ClearOptions();
            var optionList = new System.Collections.Generic.List<Dropdown.OptionData>()
            {
                new Dropdown.OptionData("OG"),
                new Dropdown.OptionData("G10"),
                new Dropdown.OptionData("G12"),
                new Dropdown.OptionData("G14"),
                new Dropdown.OptionData("G16"),
                new Dropdown.OptionData("G18"),
                new Dropdown.OptionData("G20")
            };
            AgeGroupDropdown.AddOptions(optionList);
        }

    }

}