using UnityEngine;
using SampleGame;
using UnityEngine.UI;
using LevelManagement.Data;

namespace LevelManagement
{
    public class MainMenu : Menu<MainMenu>
    {
        [Header("Player Name")]
        [SerializeField] DataManager dataManager;
        [SerializeField] InputField inputField;

        protected override void Awake()
        {
            base.Awake();
            dataManager = Object.FindObjectOfType<DataManager>();
        }

        private void Start()
        {
            LoadData();
        }

        private void LoadData ()
        {
            if(dataManager != null && inputField != null)
            {
                dataManager.Load();
                inputField.text = dataManager._playerName;
            }
        }

        public void OnPlayerNameValueChanged (string name)
        {
            if (dataManager != null)
                dataManager._playerName = name;
        }

        public void OnPlayerNameEdit ()
        {
            if (dataManager != null)
                dataManager.Save();
        }

        public void OnPlayPressed()
        {
            //LevelLoader.LoadNextLevel();
            //GameMenu.Open();

            LevelSelectionMenu.Open();
        }

        public void OnSettingPressed()
        {
            SettingMenu.Open();
        }

        public void OnCreditsPressed()
        {
            CreditsScreen.Open();
        }

        public override void OnBackPressed()
        {
            Application.Quit();
        }
    } 
}
