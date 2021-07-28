using System;

namespace LevelManagement.Data
{
    [Serializable]
    public class SaveData
    {
        public string hashValue;
        
        public string playeName;
        private readonly string defaultPlayerName = "Player";

        public float masterVolume;
        public float sfxVolume;
        public float musicVolume;

        public SaveData ()
        {
            hashValue = string.Empty;

            playeName = defaultPlayerName;
            masterVolume = 0f;
            sfxVolume = 0f;
            musicVolume = 0f;
        }
    } 
}
