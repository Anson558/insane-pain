using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    private static Music instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy (gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad( gameObject );
        }
    }

    
    

    
}
