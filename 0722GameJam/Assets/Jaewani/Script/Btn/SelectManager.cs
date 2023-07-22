using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectManager : MonoBehaviour
{
    public static SelectManager instance;

    public List<PassiveBtn> passiveBtns = new List<PassiveBtn>();
    public List<ActiveBtn> activeBtns = new List<ActiveBtn>();

    public CardScript passiveCard;
    public CardScript activeCard;
    public CardScript statCard;


    public GameObject SelectPanel;

    public bool isSelect;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

    }
    void Start()
    {

    }

    void Update()
    {

    }

    public static void StartSelect() => instance._StartSelect();
    public static void EndSelect() => instance._EndSelect();
    public void _StartSelect()
    {
        passiveCard.passiveBtn = _RandomPassive();
        activeCard.activeBtn = _RandomActive();
        isSelect = true;
        SelectPanel.SetActive(true);
        GameManager.instance.Ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);

    }
    public void _EndSelect()
    {
        isSelect = false;
        SelectPanel.SetActive(false);
        GameManager.instance.Ball.GetComponent<Rigidbody2D>().velocity = GameManager.instance.Ball.GetComponent<Ball>().levelupVelocity;
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
