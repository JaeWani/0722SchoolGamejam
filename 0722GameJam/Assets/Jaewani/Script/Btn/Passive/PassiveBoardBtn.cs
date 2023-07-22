using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveBoardBtn : PassiveBtn
{
    private void Start()
    {
        Description = "�÷��̾� ���� �ؿ� ���� ���带 �ϳ� �� �����մϴ�. \n ���尡 �̹� �����Ѵٸ�, ������ ���̸� ������ŵ�ϴ�.";
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
