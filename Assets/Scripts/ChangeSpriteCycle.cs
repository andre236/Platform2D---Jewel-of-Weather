using UnityEngine;
using Manager;

public class ChangeSpriteCycle : MonoBehaviour
{
    [SerializeField]
    private Sprite _daySprite;
    [SerializeField]
    private Sprite _nightSprite;

    private SpriteRenderer _currentSprite;

    void Awake()
    {
        _currentSprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(GameManager.Instance.CurrentCycle == GameManager.DayNightCycle.Day)
        {
            _currentSprite.sprite = _daySprite;
        }
        else
        {
            _currentSprite.sprite = _nightSprite;
        }
    }

}
