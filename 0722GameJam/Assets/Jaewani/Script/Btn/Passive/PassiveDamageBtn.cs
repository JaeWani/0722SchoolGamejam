using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveDamageBtn : PassiveBtn
{
    
    public override void BtnClick()
    {
        base.BtnClick();
        var ball = GameManager.instance.Ball.GetComponent<Ball>();
        var skill = ball.GetComponent<PassiveDamage>();
        if (skill.IsSkill == false)
            skill.IsSkill = true;
        else
            skill.Damage += 0.1f;
        skill.Lv++;
    }
}
