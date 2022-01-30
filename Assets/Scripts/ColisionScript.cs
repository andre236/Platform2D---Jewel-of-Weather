using UnityEngine;
using Manager;

public class ColisionScript : MonoBehaviour
{
    [SerializeField]
    private PolygonCollider2D _polygonCollider2D;

    private void Awake()
    {
        _polygonCollider2D = GetComponentInChildren<PolygonCollider2D>();
    }

    void Start()
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

    private void Update()
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
