using UnityEngine;
using UnityEngine.SceneManagement;


public class DataPlayer : MonoBehaviour
{
    public int JewelAmount { get; private set; } = 0;

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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }


}
