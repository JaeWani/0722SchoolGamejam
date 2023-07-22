using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveBoard : PassiveSkill
{
    public GameObject autoBoard;
    public bool IsSpawnBoard = false;
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
            Instantiate(autoBoard,new Vector2(0,-3.5f),Quaternion.identity);
            IsSpawnBoard = true;
        }
    }
}
