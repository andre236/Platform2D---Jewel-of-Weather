using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private GameObject _player;

    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    void LateUpdate()
    {
        transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, -10f);
    }
}
