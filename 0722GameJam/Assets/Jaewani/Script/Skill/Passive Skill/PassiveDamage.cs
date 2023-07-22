using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveDamage : PassiveSkill
{
    public bool IsDamageUp = false;
    public float Damage { get { return damage; } set { damage = value; DamageUp(); } }
    private float damage = 1.3f;

    void Start()
    {

    }

    void Update()
    {

    }
    protected override void SkillAbility()
    {
        base.SkillAbility();
        if (IsDamageUp == false)
        {
            GameManager.instance.Ball.GetComponent<Ball>().ballStat.ballDamage *= damage;
            IsDamageUp = true;
        }
    }
    private void DamageUp()
    {
        GameManager.instance.Ball.GetComponent<Ball>().ballStat.ballDamage *= 1.1f;
    }
}
