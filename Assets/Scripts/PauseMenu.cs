using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    [SerializeField] private float waitTime;
    //Quirell
    private GameObject quirell;
    private Rigidbody2D quirellRb;
    //Circle
    private GameObject circle;
    private Animator circleWipeAnim;


    // Start is called before the first frame update
    void Start()
    {
        //Quirell
        quirell = GameObject.FindGameObjectWithTag("Player");
        quirellRb = quirell.GetComponent<Rigidbody2D>();
        //Circle
        circle = GameObject.Find("Circle");
        circleWipeAnim = circle.GetComponent<Animator>();
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        StartCoroutine(MenuIEnumerator());
    }

    public void QuitGame()
    {
        Application.Quit();
        print("QuitGame");
    }

    public void PauseGame(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    IEnumerator MenuIEnumerator()
    {
        Time.timeScale = 0;
        //quirellRb.constraints = RigidbodyConstraints2D.FreezePosition;
        circleWipeAnim.SetTrigger("start");
        yield return new WaitForSecondsRealtime(.8f);
        SceneManager.LoadScene(0);
    }

   
    

    
}
