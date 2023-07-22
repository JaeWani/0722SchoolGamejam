using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct BlockStat
{
    public float blockHp;
    public float blockMaxHp;
}

public class Block : MonoBehaviour
{
    public BlockStat blockStat = new BlockStat();
    void Start()
    {
        blockStat.blockHp = blockStat.blockMaxHp;
    }

    void Update()
    {
        CheckHP();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Hit(collision.gameObject);
        }
    }
    private void Hit(GameObject ball)
    {
        BallStat ballStat = new BallStat();
        if (ball.TryGetComponent(out Ball ballObj))
        {
            ballStat = ballObj.ballStat;
        }
        else 
        {
            ballStat = ball.GetComponent<ActiveBall>().ballStat;
        }
        blockStat.blockHp -= ballStat.ballDamage;
    }
    private void CheckHP()
    {
        if (blockStat.blockHp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
