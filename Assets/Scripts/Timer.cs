using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    

    [SerializeField] private TextMeshProUGUI gameTimerText;
    float gameTimer = 0f;
    private static Timer instance;

    void Awake()
    {
        //Dont Destory on scene load
        if (instance != null)
        {
            Destroy (gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name != "Ending")
        {
            int milliseconds = (int)(gameTimer * 100);
            int seconds = (int)(gameTimer % 60);
            int minutes = (int)(gameTimer /60) % 60;
            milliseconds = milliseconds % 100;


            string timerString = string.Format("{0:00}:{1:00}:{2:00}",minutes,seconds,milliseconds);

            if (scene.buildIndex > 1)
            {
                gameTimer += Time.deltaTime;
                gameTimerText.text = timerString;
            }
            if (scene.buildIndex <= 1)
            {
                gameTimerText.text = "";
                gameTimer = 0;
            }
        }
    }
}
