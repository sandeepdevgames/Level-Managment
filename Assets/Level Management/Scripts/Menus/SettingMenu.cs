using UnityEngine;
using UnityEngine.UI;
using LevelManagement.Data;

namespace LevelManagement
{
    public class SettingMenu : Menu<SettingMenu>
    {
        [Header("Sliders")]
        [SerializeField] Slider masterVolumeSlider;
        [SerializeField] Slider sfxVolumeSlider;
        [SerializeField] Slider musicVolumeSlider;

        [Header("Script")]
        [SerializeField] DataManager dataManager;

        protected override void Awake()
        {
            base.Awake();
            dataManager = Object.FindObjectOfType<DataManager>();
        }

        private void Start()
        {
            LoadData();
        }

        public void OnMasterVolumeChanged (float volume)
        {
            if (dataManager != null)
                dataManager._masterVolume = volume;
        }

        public void OnSfxVolumeChanged (float volume)
        {
            if (dataManager != null)
                dataManager._sfxVolume = volume;
        }

        public void OnMusicVolumeChanged (float volume)
        {
            if (dataManager != null)
                dataManager._musicVolume = volume;
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();

            dataManager.Save();
        }

        public void LoadData()
        {
            if (dataManager == null || masterVolumeSlider == null || sfxVolumeSlider == null || musicVolumeSlider == null)
                return;

            dataManager.Load();

            masterVolumeSlider.value = dataManager._masterVolume;
            sfxVolumeSlider.value = dataManager._sfxVolume;
            musicVolumeSlider.value = dataManager._musicVolume;
        }
    } 
}
