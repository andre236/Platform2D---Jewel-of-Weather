using UnityEngine;
using Manager;

public class KeyScript : MonoBehaviour
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
