using UnityEngine;
using UnityEngine.SceneManagement;
using Manager;

public class DataPlayer : MonoBehaviour
{
    public int JewelAmount { get; private set; } = 0;

    [field:SerializeField]
    public bool HaveKey { get; private set; } = false;

    public void DecrementJewel()
    {
        JewelAmount--;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Jewel"))
        {
            JewelAmount++;
        }

        if (collision.gameObject.CompareTag("Key"))
        {
            HaveKey = true;
        }

        if (collision.gameObject.CompareTag("Dead"))
        {
            GameManager.Instance.ChangeDayCycleToStart();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (collision.gameObject.CompareTag("Door") && HaveKey)
        {
            AudioManager.Instance.PlayBGM(3);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }


}
