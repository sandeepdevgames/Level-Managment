using UnityEngine;

namespace LevelManagement.Data
{
    public class DataManager : MonoBehaviour
    {
        [Header("Component")]
        private SaveData saveData;
        private JsonSaver jsonSaver;

        public float _masterVolume
        {
            get { return saveData.masterVolume; }
            set { saveData.masterVolume = value; }
        }

        public float _sfxVolume
        {
            get { return saveData.sfxVolume; }
            set { saveData.sfxVolume = value; }
        }

        public float _musicVolume
        {
            get { return saveData.musicVolume; }
            set { saveData.musicVolume = value; }
        }

        public string _playerName
        {
            get { return saveData.playeName; }
            set { saveData.playeName = value; }
        }

        private void Awake()
        {
            saveData = new SaveData();
            jsonSaver = new JsonSaver();
        }

        public void Save()
        {
            jsonSaver.Save(saveData);
        }

        public void Load()
        {
            jsonSaver.Load(saveData);          
        }
    }
}
