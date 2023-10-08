using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Animator circleWipeAnim;
    [SerializeField] private float waitTime;

    private void Start()
    {
        //NoMouse
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }

    public void PlayGame()
    {
        StartCoroutine(PlayGameIEnumerator());
    }

    public void QuitGame()
    {
        StartCoroutine(QuitGameIEnumerator());
    }

    public void Chapter1()
    {
        StartCoroutine(PlayGameIEnumerator());
    }

    public void Chapter2()
    {
        StartCoroutine(Chapter2IEnumerator());
    }

    public void Chapter3()
    {
        StartCoroutine(Chapter3IEnumerator());
    }

    public void Farewell()
    {
        StartCoroutine(FarewellIEnumerator());
    }

    public void Chapters()
    {
        StartCoroutine(ChaptersIEnumerator());
    }

    public void Back()
    {
        StartCoroutine(BackIEnumerator());
    }

    public void Controls()
    {
        StartCoroutine(ControlsIEnumerator());
    }

    IEnumerator PlayGameIEnumerator()
    {
        circleWipeAnim.SetTrigger("start");
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("PrisonCell");
    }

    IEnumerator QuitGameIEnumerator()
    {
        yield return new WaitForSeconds(.1f);
        Application.Quit();
        print("QuitGame");
    }

    IEnumerator Chapter2IEnumerator()
    {
        circleWipeAnim.SetTrigger("start");
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("2,1");
    }

    IEnumerator Chapter3IEnumerator()
    {
        circleWipeAnim.SetTrigger("start");
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("3,1");
    }

    IEnumerator FarewellIEnumerator()
    {
        circleWipeAnim.SetTrigger("start");
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("Farewell");
    }

    IEnumerator ChaptersIEnumerator()
    {
        circleWipeAnim.SetTrigger("start");
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(1);
    }

    IEnumerator BackIEnumerator()
    {
        circleWipeAnim.SetTrigger("start");
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(0);
    }

    IEnumerator ControlsIEnumerator()
    {
        circleWipeAnim.SetTrigger("start");
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(2);
    }
    

    
}
