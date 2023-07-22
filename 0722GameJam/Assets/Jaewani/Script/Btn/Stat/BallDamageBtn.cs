
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDamageBtn : StatBtn
{
    protected override void BtnClick()
    {
        base.BtnClick();
        var ball = GameManager.instance.Ball.GetComponent<Ball>();
        ball.ballStat.ballDamage += 10;
    }
}
