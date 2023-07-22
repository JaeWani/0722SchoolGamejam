using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveExplosion : PassiveSkill
{
    [SerializeField] private GameObject ExplosionRange;
    
    void Start()
    {

    }

    void Update()
    {

    }
    protected override void SkillAbility()
    {
        base.SkillAbility();
        Debug.Log("Æø¹ß");
        Instantiate(ExplosionRange,transform.position,Quaternion.identity);
    }
}
