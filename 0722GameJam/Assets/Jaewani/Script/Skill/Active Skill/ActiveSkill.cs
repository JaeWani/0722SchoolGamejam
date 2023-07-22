using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSkill : BallSkill
{
    Coroutine a;

    public KeyCode key;
    public bool CanSkill;
    public float Delay;
    void Start()
    {
    }

    void Update()
    {

    }
    public void Active()
    {
        if (IsSkill == true)
        {
            if (Input.GetKeyDown(key))
            {
                if (CanSkill == true)
                {
                    SkillAblity();
                    if (a != null)
                        StopCoroutine(a);
                    a = StartCoroutine(ActiveDelay());
                }
            }
        }
    }
    public WaitForSecondsRealtime wait;
    IEnumerator ActiveDelay()
    {
        CanSkill = false;
        yield return new WaitForSecondsRealtime(Delay);
        CanSkill = true;
    }
    protected virtual void SkillAblity()
    {

    }
}
