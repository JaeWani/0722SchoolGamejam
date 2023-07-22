using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveBoard : ActiveSkill
{
    public float Duration;
    void Start()
    {

    }

    void Update()
    {

    }
    protected override void SkillAblity()
    {
        base.SkillAblity();
        StartCoroutine(Buff());
    }
    IEnumerator Buff()
    {
        Debug.Log("das");
        StartCoroutine(BoardBuff());
        yield return new WaitForSecondsRealtime(Duration);
        StartCoroutine(BoardDeBuff());
    }
    IEnumerator BoardBuff()
    {
        GameObject board = GameManager.instance.Board;
        while (board.transform.localScale.x < 7.5f)
        {
            yield return null;
            float x = board.transform.localScale.x + (5 * Time.deltaTime);
            board.transform.localScale = new Vector2(x, transform.localScale.y);
        }
    }
    IEnumerator BoardDeBuff()
    {
        GameObject board = GameManager.instance.Board;
        while (board.transform.localScale.x > 1.5f)
        {
            yield return null;
            float x = board.transform.localScale.x - (5 * Time.deltaTime);
            board.transform.localScale = new Vector2(x, transform.localScale.y);
        }
    }
}
