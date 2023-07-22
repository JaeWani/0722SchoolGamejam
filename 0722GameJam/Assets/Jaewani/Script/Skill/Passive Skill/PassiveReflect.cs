using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveReflect : PassiveSkill
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    protected override void SkillAbility()
    {
        base.SkillAbility();
        GameManager.instance.Ball.GetComponent<Ball>().ballStat.ballReflectCount += 5;
    }
}
