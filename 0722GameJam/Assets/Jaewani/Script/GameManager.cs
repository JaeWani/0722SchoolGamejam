using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public FadeScript FadeScript;
    public delegate void RoundStartDelegate();
    public RoundStartDelegate startDelegate;

    public static GameManager instance;

    public int Round = 1;

    public int BlockLineCount = 5;
    public List<GameObject> BlockPrefabs = new List<GameObject>();

    public GameObject BossPrefab;

    public bool isRound;

    public bool isBoss;

    public GameObject Ball;
    public GameObject Board;
    public GameObject Blocks;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    void Start()
    {
        RoundStart();
    }

    void Update()
    {
        CheckRoundEnd();
    }
    public static void RoundStart() => instance._RoundStart();
    public static void RoundEnd() => instance._RoundEnd();
    public static void CheckRoundEnd() => instance._CheckRoundEnd();

    private void _RoundStart()
    {
        UIManager.FadeIn();
        Round++;
        isRound = true;
        if (Round % 5 == 0)
        {
            isBoss = true;
            _CreateBoss();
        }
        else
            _CreatBlock();

        Ball.transform.position = new Vector2(0,0);
        Ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        Ball.GetComponent<Ball>().ballStat.ballReflectCount = Ball.GetComponent<Ball>().ballStat.maxBallReflectCount;

        StartCoroutine(_RoundStart());
        IEnumerator _RoundStart()
        {
            yield return StartCoroutine(UIManager.instance.CountDown());
            Ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0,-10);
        }
    }
    private void _CreateBoss()
    {
        var bossBlock =  Instantiate(BossPrefab, Blocks.transform).GetComponent<Block>();
        bossBlock.blockStat.blockMaxHp = Ball.GetComponent<Ball>().ballLevel * 100000;
        bossBlock.blockStat.blockHp = bossBlock.blockStat.blockMaxHp;
        bossBlock.blockStat.giveExp = 5000 * Ball.GetComponent<Ball>().ballLevel;

    }
    private void _CreatBlock()
    {
        float y = 4.5f;
        for (int i = 0; i < BlockLineCount; i++)
        {
            float x = -2;
            for (int j = 0; j < 5; j++)
            {
                var block = Instantiate(BlockPrefabs[0], new Vector2(x, y), Quaternion.identity);
                block.transform.parent = Blocks.transform;
                x++;
            }
            y -= 0.5f;
        }
    }
    private void _RoundEnd()
    {
        isBoss = false;
        if (isRound == true) 
        {
            Ball.transform.position = new Vector2(0, 0);
            Ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            StartCoroutine(_RoundEnd());
            IEnumerator _RoundEnd()
            {
                yield return StartCoroutine(UIManager.instance._FadeOut());
                DestroyAllBlock();
                yield return new WaitForSecondsRealtime(2);
                RoundStart();
            }
            isRound = false;
        }

        
        if (startDelegate != null)
            startDelegate();
    }
    private void _CheckRoundEnd()
    {
        if (isRound == true)
        {
            if (Blocks.transform.childCount <= 0)
            {
                RoundEnd();
                isRound = false;
            }

        }
    }
    void DestroyAllBlock()
    {
        for (int i = 0; i < Blocks.transform.childCount; i++)
        {
            Destroy(Blocks.transform.GetChild(i).gameObject);
        }
    }
}
