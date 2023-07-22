using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveReflectBtn : PassiveBtn
{
    public override void BtnClick()
    {
        base.BtnClick();
        var ball = GameManager.instance.Ball.GetComponent<Ball>();
        var refelect = ball.GetComponent<PassiveReflect>();

        if (refelect.IsSkill)
            refelect.IsSkill = true;
        else
            refelect.PluseReflect += 2;
        refelect.Lv++;
    }
}
