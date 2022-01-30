using UnityEngine;
using Manager;

namespace Object
{
    public class JewelScript : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                AudioManager.Instance.PlaySoundEffect(1);  
                gameObject.SetActive(false);
            }
        }
    }
}