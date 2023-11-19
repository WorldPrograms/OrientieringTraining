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

        public void Show()
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }

        public void Hide()
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }

    }

}