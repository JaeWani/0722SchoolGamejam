using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    private const int LeftMouseButton = 0;

    public AudioClip clickSound; // 클릭 소리를 위한 AudioClip을 Inspector에서 설정해주세요.

    void Update()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton))
        {
            StartCoroutine(LoadSceneAfterDelay("SampleScene_3", 1.5f));
        }
    }

    IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
        // 클릭 소리 재생
        if (clickSound != null)
        {
            AudioSource.PlayClipAtPoint(clickSound, Camera.main.transform.position);
        }

        // delay 초 후에 씬을 전환
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
