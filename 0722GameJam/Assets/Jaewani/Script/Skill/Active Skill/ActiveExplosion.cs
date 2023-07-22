using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveExplosion : ActiveSkill
{
    public GameObject Explosion;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    protected override void SkillAblity()
    {
        base.SkillAblity();
        Instantiate(Explosion, transform.position, Quaternion.identity);
    }
}
