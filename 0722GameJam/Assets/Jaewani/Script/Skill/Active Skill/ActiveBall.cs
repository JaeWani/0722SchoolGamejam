using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveBall : MonoBehaviour
{
    // Start is called before the first frame update
    public BallStat ballStat = new BallStat();

    public PassiveSkill explosion;

    private Rigidbody2D RB;
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void BoardReflect(GameObject board)
    {
        RB.velocity = new Vector2(transform.position.x - board.transform.position.x, 1).normalized * ballStat.ballSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Board"))
        {
            BoardReflect(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Block"))
        {
            explosion.IsSkill =  GameManager.instance.Ball.GetComponent<Ball>().passiveSkills[0].IsSkill;
            explosion.Passive();
        }
    }
}
