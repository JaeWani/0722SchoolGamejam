using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveBoardBtn : PassiveBtn
{
   
    public override void BtnClick()
    {
        base.BtnClick();
        var ball = GameManager.instance.Ball.GetComponent<Ball>();
        var board = ball.GetComponent<PassiveBoard>();

        if (board.IsSkill == false)
            board.IsSkill = true;
        else
            board.AutoBoardSize += 0.5f;
        board.Lv++;
    }
}
