using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassiveExplosionBtn : PassiveBtn
{
    
    public override void BtnClick()
    {
        base.BtnClick();
        var ball = GameManager.instance.Ball.GetComponent<Ball>();
        var skill = ball.GetComponent<PassiveExplosion>();
        if (skill.IsSkill == false)
            skill.IsSkill = true;
        else 
            skill.ExplosionDamage += 0.1f;
        skill.Lv++;
    }
}
