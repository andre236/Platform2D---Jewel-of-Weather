using UnityEngine;

public class BoardMessage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Mostrar Mensagem
        }
    }
}
