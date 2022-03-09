using UnityEngine;
using Manager;

public class ColisionScript : MonoBehaviour
{
    [SerializeField]
    private PolygonCollider2D _polygonCollider2D;

    [SerializeField]
    private bool _isBoxCollider2D = false;

    private BoxCollider2D _boxColl;

    private void Awake()
    {
        if (_isBoxCollider2D)
        {
            _boxColl = GetComponent<BoxCollider2D>();
        }
        else
        {
            _polygonCollider2D = GetComponentInChildren<PolygonCollider2D>();
        }
    }

    void Start()
    {
        if (_isBoxCollider2D)
        {
            if (gameObject.CompareTag("Black") && GameManager.Instance.CurrentCycle == GameManager.DayNightCycle.Night || gameObject.CompareTag("White") && GameManager.Instance.CurrentCycle == GameManager.DayNightCycle.Day)
            {
                _boxColl.enabled = true;
            }
            else
            {
                _boxColl.enabled = false;
            }
        }
        else
        {
            if (gameObject.CompareTag("Black") && GameManager.Instance.CurrentCycle == GameManager.DayNightCycle.Night || gameObject.CompareTag("White") && GameManager.Instance.CurrentCycle == GameManager.DayNightCycle.Day)
            {
                _polygonCollider2D.enabled = true;
            }
            else
            {
                _polygonCollider2D.enabled = false;
            }
        }

    }

    private void Update()
    {
        if (_isBoxCollider2D)
        {
            if (gameObject.CompareTag("Black") && GameManager.Instance.CurrentCycle == GameManager.DayNightCycle.Night || gameObject.CompareTag("White") && GameManager.Instance.CurrentCycle == GameManager.DayNightCycle.Day)
            {
                _boxColl.enabled = true;
            }
            else
            {
                _boxColl.enabled = false;
            }
        }
        else
        {
            if (gameObject.CompareTag("Black") && GameManager.Instance.CurrentCycle == GameManager.DayNightCycle.Night || gameObject.CompareTag("White") && GameManager.Instance.CurrentCycle == GameManager.DayNightCycle.Day)
            {
                _polygonCollider2D.enabled = true;
            }
            else
            {
                _polygonCollider2D.enabled = false;
            }
        }


    }

}
