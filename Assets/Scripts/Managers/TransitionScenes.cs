using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TransitionScenes : MonoBehaviour
{

    private bool _onConfirmedLoad = false;
    private Image _transition;

    void Awake()
    {
        _transition = GameObject.Find("Transition").GetComponent<Image>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Submit") && !_onConfirmedLoad)
        {
            _onConfirmedLoad = true;
            StartCoroutine("StartTransitionNextScene");
        }   
    }

    IEnumerator StartTransitionNextScene()
    {
        _transition.GetComponent<Animator>().SetTrigger("FadeIn");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(1);
    }
}
