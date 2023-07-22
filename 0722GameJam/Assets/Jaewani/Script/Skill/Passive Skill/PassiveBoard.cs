using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveBoard : PassiveSkill
{
    public GameObject autoBoard;
    public bool IsSpawnBoard = false;
    public float AutoBoardSize;
    AutoBoard board;
    void Start()
    {
        
    }

    void Update()
    {
    }
    protected override void SkillAbility()
    {
        base.SkillAbility();
        if (IsSpawnBoard == false) 
        {
            board = Instantiate(autoBoard,new Vector2(0,-2.5f),Quaternion.identity).GetComponent<AutoBoard>();
            IsSpawnBoard = true;
        }
    }
}
