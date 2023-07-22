using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDamage : ActiveSkill
{
    public float Duration;
    public float PlusDamage;
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
            float plusDmg = ball.ballStat.ballDamage * PlusDamage;
            ball.ballStat.ballDamage += plusDmg;
            yield return duration;
            ball.ballStat.ballDamage -= plusDmg;
        }
    }

}
