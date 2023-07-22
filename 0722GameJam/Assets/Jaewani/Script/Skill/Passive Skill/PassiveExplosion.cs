using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveExplosion : PassiveSkill
{
    [SerializeField] private GameObject ExplosionRange;
    public float ExplosionDamage = 0.3f;
    
    protected override void SkillAbility()
    {
        base.SkillAbility();
        Debug.Log("Æø¹ß");
        var explosion = Instantiate(ExplosionRange,transform.position,Quaternion.identity).GetComponent<Explosion>();
        explosion.ExplosionDmg = ExplosionDamage;
    }
}
