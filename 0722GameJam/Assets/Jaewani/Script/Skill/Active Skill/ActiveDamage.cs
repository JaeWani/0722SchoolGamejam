using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDamage : ActiveSkill
{
    public float Duration;
    WaitForSeconds duration;
    void Start()
    {
        duration = new WaitForSeconds(Duration);
    }

    void Update()
    {

    }
    protected override void SkillAblity()
    {
        base.SkillAblity();
        StartCoroutine(SkillAblity());
        IEnumerator SkillAblity()
        {
            var ball = GameManager.instance.Ball.GetComponent<Ball>();
            float plusDmg = ball.ballStat.ballDamage * 2;
            ball.ballStat.ballDamage += plusDmg;
            yield return duration;
            ball.ballStat.ballDamage -= plusDmg;
        }
    }

}
