using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardScript : MonoBehaviour
{
    public enum CardState
    {
        Passive,
        Active,
        Stat
    }
    public CardState curState;
    [SerializeField] Image Icon;
    [SerializeField] Text Name;
    [SerializeField] Text Description;

    private Button btn;

    public PassiveBtn passiveBtn;
    public ActiveBtn activeBtn;
    public StatBtn statBtn;
    void Start()
    {
    }

    void Update()
    {

    }
    private void OnEnable()
    {
        if (btn == null)
            btn = GetComponent<Button>();
        AddInfo();
    }
    void AddInfo()
    {
        switch (curState)
        {
            case CardState.Active:
                Icon.sprite = activeBtn.icon;
                Name.text = activeBtn.Name;
                Description.text = activeBtn.Description;
                btn.onClick.AddListener(() => activeBtn.BtnClick());
                btn.onClick.AddListener(() => SelectManager.EndSelect());
                break;

            case CardState.Passive:
                Icon.sprite = passiveBtn.icon;
                Name.text = passiveBtn.Name;
                Description.text = passiveBtn.Description;
                btn.onClick.AddListener(() => passiveBtn.BtnClick());
                btn.onClick.AddListener(() => SelectManager.EndSelect());
                break;

            case CardState.Stat:
                Icon.sprite = statBtn.icon;
                Name.text = statBtn.Name;
                Description.text = statBtn.Description;
                btn.onClick.AddListener(() => statBtn.BtnClick());
                btn.onClick.AddListener(() => SelectManager.EndSelect());
            break;
        }
    }
}
