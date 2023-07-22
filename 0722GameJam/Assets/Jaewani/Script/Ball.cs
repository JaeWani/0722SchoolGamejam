using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct BallStat
{
    public int ballLv;

    public float ballDamage;
    public float ballSpeed;
    public int ballReflectCount;
}

public class Ball : MonoBehaviour
{
    public List<PassiveSkill> passiveSkills = new List<PassiveSkill>();
    public List<ActiveSkill> activeSkills = new List<ActiveSkill>();

    public BallStat ballStat = new BallStat();

    private Rigidbody2D RB;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        RB.velocity = new Vector2(0, -ballStat.ballSpeed);
        GameManager.instance.startDelegate = new GameManager.RoundStartDelegate(passiveSkills[3].Passive);

        activeSkills[0].wait = new WaitForSecondsRealtime(activeSkills[0].Delay);
    }

    void Update()
    {
        passiveSkills[1].Passive();
        passiveSkills[2].Passive();

        activeSkills[0].Active();
        activeSkills[1].Active();
        activeSkills[2].Active();
        activeSkills[3].Active();
    }
    private void BoardReflect(GameObject board)
    {
        RB.velocity = new Vector2(transform.position.x - board.transform.position.x, 1).normalized * ballStat.ballSpeed;
        ballStat.ballReflectCount--;
        CheckReflectCount();
    }
    private void CheckReflectCount()
    {
        if (ballStat.ballReflectCount < 0)
        {
            GameManager.RoundEnd();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            passiveSkills[0].Passive();
        }
        else if (collision.gameObject.CompareTag("Board"))
        {

            BoardReflect(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("DownWall"))
        {
            GameManager.RoundEnd();
        }
        else if (collision.gameObject.CompareTag("Wall")) 
        { 
        
        }
    }
}
