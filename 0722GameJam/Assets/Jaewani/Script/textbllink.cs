using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textbllink : MonoBehaviour
{
    public Text text;
    IEnumerator textblink()
    {
        while (true)
        {
        Color color = text.color;
        while (text.color.a < 1)
        {
            color.a += Time.deltaTime;
            text.color = color;
            yield return null;
        }
        while (text.color.a > 0)
        {
            color.a -= Time.deltaTime;
            text.color = color;
            yield return null;
        }
        }
    }
    void Start()
    {
        StartCoroutine(textblink());
    }

    
    void Update()
    {
        
    }
}
