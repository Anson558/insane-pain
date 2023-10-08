using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(Credits());
    }

    IEnumerator Credits()
    {
        yield return new WaitForSeconds (5f);
        SceneManager.LoadScene("Credits");
    }
}
