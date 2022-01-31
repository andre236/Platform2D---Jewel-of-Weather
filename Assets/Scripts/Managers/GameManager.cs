using UnityEngine;

namespace Manager
{
    public class GameManager : MonoBehaviour
    {
        public bool IsRunning { get; private set; }
        public bool OnDialogue { get; private set; }

        public static GameManager Instance;

        public CurrentScriptPhase CurrentScriptPhaseCycle;


        public enum DayNightCycle { Day, Night };
        public DayNightCycle CurrentCycle;
        public DayNightCycle StartCycle;

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

            CurrentScriptPhaseCycle = FindObjectOfType<CurrentScriptPhase>();
            
            CurrentCycle = CurrentScriptPhaseCycle.CurrentCyclePhase;
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

        public void ChangeDayCycleToStart()
        {
            CurrentCycle = StartCycle;
        }

    }
}