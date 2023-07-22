using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject Fade;
    public CanvasGroup FadecanvasGroup;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    void Start()
    {
        FadecanvasGroup = Fade.GetComponent<CanvasGroup>();
    }

    void Update()
    {

    }
    public static void FadeOut() { instance.StartCoroutine(instance._FadeOut()); }
    public static void FadeIn() { instance.StartCoroutine(instance._FadeIn()); }

    public bool isFadeOut;
    public IEnumerator _FadeOut()
    {
        if (isFadeOut == false)
        {
        Debug.Log("FadeOut");
            isFadeOut = true;
            while (FadecanvasGroup.alpha < 1)
            {
                yield return null;
                FadecanvasGroup.alpha += Time.deltaTime;
            }
            isFadeOut = false;
        }
    }
    public bool isFadeIn;
    public IEnumerator _FadeIn()
    {
        if (isFadeIn == false)
        {
        Debug.Log("FadeIn");
            isFadeIn = true;
            while (FadecanvasGroup.alpha > 0)
            {
                yield return null;
                FadecanvasGroup.alpha -= Time.deltaTime;
            }
            isFadeIn = false;
        }
    }
}
