using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectManager : MonoBehaviour
{
    public List<PassiveBtn> passiveBtns = new List<PassiveBtn>();
    public List<ActiveBtn> activeBtns = new List<ActiveBtn>();
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private PassiveBtn _RandomPassive()
    {
        var rand = Random.Range(0, passiveBtns.Count);
        return passiveBtns[rand];
    }
    private ActiveBtn _RandomActive() 
    {
        var rand = Random.Range(0, activeBtns.Count);
        return activeBtns[rand];
    }
}
