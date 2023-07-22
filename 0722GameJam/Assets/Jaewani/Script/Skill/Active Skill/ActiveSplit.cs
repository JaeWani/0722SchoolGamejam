using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSplit : ActiveSkill
{
    public GameObject BallObject;
    void Start()
    {
    }

    void Update()
    {
        
    }
    protected override void SkillAblity()
    {
        base.SkillAblity();
        for (int i = 0; i < 5; i++) 
        {
            var obj =  Instantiate(BallObject,transform.position, Quaternion.identity);
            var rb = obj.GetComponent<Rigidbody2D>();
            var ball = obj.GetComponent<ActiveBall>();
            ball.ballStat = GameManager.instance.Ball.GetComponent<Ball>().ballStat;

            float x = Random.Range(-1,2);
            float y = Random.Range(-1,2);

            rb.velocity = new Vector2(x,y) * ball.ballStat.ballSpeed;
        }
    }
}
