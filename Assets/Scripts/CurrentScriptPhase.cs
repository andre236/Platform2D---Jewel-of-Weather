using UnityEngine;
using Manager;


public class CurrentScriptPhase : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.Instance.CurrentCycle = GameManager.DayNightCycle.Night;
    }

}
