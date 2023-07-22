using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveDamage : PassiveSkill
{
    public bool IsDamageUp = false;
    void Start()
    {

    }

    void Update()
    {
        
    }
    protected override void SkillAbility()
    {
        base.SkillAbility();
        if (IsDamageUp == false) 
        {
            GameManager.instance.Ball.GetComponent<Ball>().ballStat.ballDamage *= 1.3f;
            IsDamageUp = true;
        }
    }
}
