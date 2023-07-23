using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamescenes2 : MonoBehaviour
{
    public FadeScript fadeScript;

    public void GameScnesCtrl()
    {
        StartCoroutine(DelayedSceneLoad());
    }
    IEnumerator DelayedSceneLoad()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
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
    
}
