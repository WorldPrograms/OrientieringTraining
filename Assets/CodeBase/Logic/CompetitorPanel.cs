using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Logic
{
    public class CompetitorPanel: MonoBehaviour
    {
        [SerializeField] private GameObject _panel;

        public InputField FirstNameField;
        public InputField LastNameField;
        public Dropdown AgeGroupDropdown;
        public Dropdown GenderDropdown;
        public InputField CustomGroupName;

        public void Awake()
        {
            DontDestroyOnLoad(this);
            print("Readuawdfawfa");
        }

        public void Hide()
        {
            _panel.SetActive(false);
        }

        public void Show()
        {
            _panel.SetActive(true);
        }
    }

}