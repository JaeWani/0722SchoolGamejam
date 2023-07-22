using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSplitBtn : ActiveBtn
{
    protected override void BtnClick()
    {
        base.BtnClick();
        var ball = GameManager.instance.Ball.GetComponent<Ball>();
        var skill = ball.GetComponent<ActiveSplit>();

        if (skill.IsSkill == false)
            skill.IsSkill = true;
        else
            skill.BallCount++;
        skill.Lv++;

    }
}