using UnityEngine;
using UnityEngine.UI;
using LevelManagement.Missions;

namespace LevelManagement
{
    [RequireComponent(typeof(MissionSelector))]
    public class LevelSelectionMenu : Menu<LevelSelectionMenu>
    {
        #region Inspector
        [SerializeField] protected Text _nameText;
        [SerializeField] protected Text _description;
        [SerializeField] protected Image _previewImage;
        #endregion

        #region Protected
        protected MissionSelector _missionSelector;
        protected MissionSpecs _currentMission;
        #endregion

        protected override void Awake()
        {
            base.Awake();
            _missionSelector = GetComponent<MissionSelector>();

            UpdateInfo();
        }

        private void OnEnable()
        {
            UpdateInfo();
        }

        public void UpdateInfo ()
        {
            _currentMission = _missionSelector.GetCurrentMission();

            _nameText.text = _currentMission?.Name;
            _description.text = _currentMission?.Description;
            _previewImage.sprite = _currentMission?.Image;
            _previewImage.color = Color.white;
        }

        public void OnNextPressed ()
        {
            _missionSelector.IncrementIndex();
            UpdateInfo();
        }

        public void OnPreviousPressed ()
        {
            _missionSelector.DecrementIndex();
            UpdateInfo();
        }

        public void OnPlayPressed()
        {
            LevelLoader.LoadLevel(_currentMission?.SceneName);
            GameMenu.Open();
        }
    }
}
