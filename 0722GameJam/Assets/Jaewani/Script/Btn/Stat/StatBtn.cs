using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatBtn : MonoBehaviour
{
    Button btn;
    public string Description;
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(() => BtnClick());
    }
    protected virtual void BtnClick()
    {

    }
}
