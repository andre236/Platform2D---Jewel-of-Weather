using UnityEngine;
using Manager;

public class FadeScript : MonoBehaviour
{
    Animator _currentAnim;
    // Start is called before the first frame update
    void Awake()
    {
        _currentAnim = GetComponent<Animator>();
    }

    private void Start()
    {
        if (GameManager.Instance.CurrentCycle == GameManager.DayNightCycle.Day && gameObject.CompareTag("White"))
        {
            _currentAnim.SetBool("IsFadein", true);
        }
        if (GameManager.Instance.CurrentCycle == GameManager.DayNightCycle.Night && gameObject.CompareTag("Black"))
        {
            _currentAnim.SetBool("IsFadein", true);
        }
        if (GameManager.Instance.CurrentCycle == GameManager.DayNightCycle.Night && gameObject.CompareTag("White"))
        {
            _currentAnim.SetBool("IsFadein", false);
        }
    }

    private void Update()
    {
        if (GameManager.Instance.CurrentCycle == GameManager.DayNightCycle.Day && gameObject.CompareTag("White") || GameManager.Instance.CurrentCycle == GameManager.DayNightCycle.Night && gameObject.CompareTag("Black"))
        {
            _currentAnim.SetBool("IsFadein", true);
        }
        else
        {
            _currentAnim.SetBool("IsFadein", false);
        }
    }

    private void OnEnable()
    {
        _currentAnim.SetBool("IsFadein", true);
    }

    private void OnDisable()
    {
        _currentAnim.SetBool("IsFadein", false);
    }

}
