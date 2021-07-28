using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement.Missions
{
    public class MissionSelector : MonoBehaviour
    {
        #region Inspector
        [SerializeField] protected MissionList missionList;
        #endregion

        #region Protected
        protected int _currentIndex = 0;
        #endregion

        #region Properties
        public int CurrentIndex => _currentIndex;
        #endregion

        public void ClampIndex()
        {
            if (missionList.TotalMissions == 0)
            {
                Debug.LogWarning("Mission data erro!!!");
                return;
            }

            if (CurrentIndex >= missionList.TotalMissions)
            {
                _currentIndex = 0;
            }

            if (CurrentIndex < 0)
            {
                _currentIndex = missionList.TotalMissions - 1;
            }
        }

        public void SetIndex (int index)
        {
            _currentIndex = index;
            ClampIndex();
        }

        public void IncrementIndex ()
        {
            SetIndex(_currentIndex + 1);
        }

        public void DecrementIndex ()
        {
            SetIndex(_currentIndex - 1);
        }

        public MissionSpecs GetMission(int index)
        {
            return missionList.GetMission(index);
        }

        public MissionSpecs GetCurrentMission ()
        {
            return missionList.GetMission(_currentIndex);
        }
    } 
}
