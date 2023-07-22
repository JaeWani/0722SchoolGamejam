using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveDamageBtn : PassiveBtn
{
    private void Start()
    {
        Description = "데미지를 30% 증가시킵니다. \n ( 2번째 선택부터 +10% )";
    }
    protected override void BtnClick()
    {
        base.BtnClick();
        var ball = GameManager.instance.Ball.GetComponent<Ball>();
        var skill = ball.GetComponent<PassiveDamage>();
        if (skill.IsSkill == false)
            skill.IsSkill = true;
        else
            skill.Damage += 0.1f;
        skill.Lv++;
    }
}
