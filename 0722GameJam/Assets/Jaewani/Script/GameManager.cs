using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public delegate void RoundStartDelegate();
    public RoundStartDelegate startDelegate;

    public static GameManager instance;

    public int Round = 1;

    public int BlockLineCount = 5;
    public List<GameObject> BlockPrefabs = new List<GameObject>();

    public bool isRound;

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
        Round++;
        Time.timeScale = 1;
        if (Round % 5 == 0)
            _CreateBoss();
        else
            _CreatBlock();
    }
    private void _CreateBoss()
    {
        Debug.Log("¿¿æ÷æ≤");
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
        DestroyAllBlock();
        Time.timeScale = 0;
        RoundStart();
        if (startDelegate != null)
            startDelegate();
    }
    private void _CheckRoundEnd()
    {
        if (isRound == false)
        {
            if (Blocks.transform.childCount <= 0)
            {
                RoundEnd();
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
