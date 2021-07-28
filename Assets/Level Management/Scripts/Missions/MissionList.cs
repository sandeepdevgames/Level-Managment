using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement.Missions
{
    [CreateAssetMenu(fileName = "MissionList", menuName = "Missions/Mission List", order = 1)]
    public class MissionList : ScriptableObject
    {
        #region Inspector
        [SerializeField] List<MissionSpecs> missions;
        #endregion

        #region Properites
        public int TotalMissions => missions.Count;
        #endregion

        public MissionSpecs GetMission (int index)
        {
            return missions[index];
        }
    } 
}
