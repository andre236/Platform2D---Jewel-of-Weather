using UnityEngine;
using Manager;

public class CollectScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySoundEffect(2);
            gameObject.SetActive(false);
        }
    }
}
