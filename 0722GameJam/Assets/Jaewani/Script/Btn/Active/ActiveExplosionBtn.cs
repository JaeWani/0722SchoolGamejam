using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveExplosionBtn : ActiveBtn
{
    public override void BtnClick()
    {
        base.BtnClick();
        var ball = GameManager.instance.Ball.GetComponent<Ball>();
        var skill = ball.GetComponent<ActiveExplosion>();

        if (skill.IsSkill == false)
            skill.IsSkill = true;
        else
            skill.ExplosionDamage += 0.2f;
        skill.Lv++;
    }
}
