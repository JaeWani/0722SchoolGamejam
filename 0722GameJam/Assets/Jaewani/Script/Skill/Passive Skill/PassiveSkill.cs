using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveSkill : BallSkill
{
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    public void Passive()
    {
        if (IsSkill == true)
        {
            SkillAbility();
        }
    }
    protected virtual void SkillAbility()
    {

    }
}
