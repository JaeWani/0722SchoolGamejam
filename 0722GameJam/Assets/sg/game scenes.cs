using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamescenes : MonoBehaviour
{
    public FadeScript fadeScript;

    public void GameScnesCtrl()
    {
        StartCoroutine(DelayedSceneLoad());
    }

    private void Start()
    {
       
        if (fadeScript != null)
        {
            fadeScript.Fade(true);
        }
        else
        {
            Debug.LogWarning("fadeScript is not assigned!");
        }
    }

    IEnumerator DelayedSceneLoad()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("SampleScene_3");
    }
}
