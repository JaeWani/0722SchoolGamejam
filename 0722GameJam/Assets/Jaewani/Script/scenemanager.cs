using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    private const int LeftMouseButton = 0;

    public AudioClip clickSound; // Ŭ�� �Ҹ��� ���� AudioClip�� Inspector���� �������ּ���.

    void Update()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton))
        {
            StartCoroutine(LoadSceneAfterDelay("SampleScene_3", 1.5f));
        }
    }

    IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
        // Ŭ�� �Ҹ� ���
        if (clickSound != null)
        {
            AudioSource.PlayClipAtPoint(clickSound, Camera.main.transform.position);
        }

        // delay �� �Ŀ� ���� ��ȯ
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
