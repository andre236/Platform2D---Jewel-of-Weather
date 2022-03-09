using UnityEngine;
using UnityEngine.SceneManagement;

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

            CurrentScriptPhaseCycle = null;

            CurrentScriptPhaseCycle = FindObjectOfType<CurrentScriptPhase>();
            


        }

        public void ChangeDayCycle()
        {
            AudioManager.Instance.PlaySoundEffect(3);
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