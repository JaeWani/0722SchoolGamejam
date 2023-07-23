using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveExplosion : ActiveSkill
{
    public AudioSource AudioSource;
    public GameObject Explosion;
    public float ExplosionDamage;
    void Start()
    {

    }

    void Update()
    {

    }
    protected override void SkillAblity()
    {
        AudioSource.Play();
        base.SkillAblity();
        var skill = Instantiate(Explosion, transform.position, Quaternion.identity).GetComponent<SkillExplosion>();
        skill.ExplosionDmg = ExplosionDamage;
    }
}
