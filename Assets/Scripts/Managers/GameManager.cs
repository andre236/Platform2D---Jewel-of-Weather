using UnityEngine;

namespace Manager
{
    public class GameManager : MonoBehaviour
    {
        public bool IsRunning { get; private set; }

        public static GameManager Instance;

        public enum DayNightCycle { Day, Night };
        public DayNightCycle CurrentCycle;

        void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            CurrentCycle = DayNightCycle.Night;
        }

        public void ChangeDayCycle()
        {
            if(CurrentCycle == DayNightCycle.Day)
            {
                CurrentCycle = DayNightCycle.Night;
            }
            else
            {
                CurrentCycle = DayNightCycle.Day;
            }
        }

    }
}