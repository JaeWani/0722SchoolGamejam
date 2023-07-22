using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveBoardBtn : ActiveBtn
{
    public override void BtnClick()
    {
        base.BtnClick();
        var ball = GameManager.instance.Ball.GetComponent<Ball>();
        var skill = ball.GetComponent<ActiveBoard>();

        if (skill.IsSkill == false)
            skill.IsSkill = true;
        else
            skill.Duration++;
        skill.Lv++;

    }
}
