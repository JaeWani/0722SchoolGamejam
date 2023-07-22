using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveBoardBtn : PassiveBtn
{
    private void Start()
    {
        Description = "플레이어 보드 밑에 작은 보드를 하나 더 생성합니다. \n 보드가 이미 존재한다면, 보드의 길이를 증가시킵니다.";
    }
    protected override void BtnClick()
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
