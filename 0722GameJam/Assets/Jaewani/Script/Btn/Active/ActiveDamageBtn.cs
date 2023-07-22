using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDamageBtn : ActiveBtn
{
    protected override void BtnClick()
    {
        base.BtnClick();
        var ball = GameManager.instance.Ball.GetComponent<Ball>();
        var skill = ball.GetComponent<ActiveDamage>();
        skill.Lv++;

        if (skill.IsSkill == false)
            skill.IsSkill = true;
        else
            skill.PlusDamage += 0.2f;
        skill.Lv++;
    }
}
