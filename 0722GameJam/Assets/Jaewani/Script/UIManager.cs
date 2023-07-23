using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header ("���̵� �� �ƿ�")]
    public GameObject Fade;
    public CanvasGroup FadecanvasGroup;

    [Header("��ų ������")]
    public Image ExplosionIcon;
    public Image ExplosionIconLocked;

    public Image DamageIcon;
    public Image DamageIconLocked;

    public Image SplitIcon;
    public Image SplitIconLocked;

    public Image BoardIcon;
    public Image BoardIconLocked;

    [Header ("ī��Ʈ �ٿ�")]
    public Text CountText;
    [Header("�������̽�")]
    public Text BallLv;
    public Text BallDamage;
    public Text Round;
    public Text ReflectCount;
    [Header("���� ���� �г�")]
    public GameObject GameOverPanel;
    public Text GameOverLevelText;
    public Button GameOverRePlayBtn;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    void Start()
    {
        FadecanvasGroup = Fade.GetComponent<CanvasGroup>();
        GameOverRePlayBtn.onClick.AddListener(() => StartCoroutine(Replay()));
    }
    IEnumerator Replay() 
    {
        yield return StartCoroutine(_FadeOut());
        SceneManager.LoadScene(1);
    }

    void Update()
    {
        SkillLocked();
        SetInterFace();
    }
    public static void FadeOut() { instance.StartCoroutine(instance._FadeOut()); }
    public static void FadeIn() { instance.StartCoroutine(instance._FadeIn()); }

    public bool isFadeOut;
    public IEnumerator _FadeOut()
    {
        if (isFadeOut == false)
        {
            FadecanvasGroup.alpha = 0;
            Debug.Log("FadeOut");
            isFadeOut = true;
            while (FadecanvasGroup.alpha < 1)
            {
                yield return null;
                FadecanvasGroup.alpha += Time.deltaTime;
            }
            isFadeOut = false;
        }
    }
    public bool isFadeIn;
    public IEnumerator _FadeIn()
    {
        if (isFadeIn == false)
        {
            FadecanvasGroup.alpha = 1;
            Debug.Log("FadeIn");
            isFadeIn = true;
            while (FadecanvasGroup.alpha > 0)
            {
                yield return null;
                FadecanvasGroup.alpha -= Time.deltaTime;
            }
            isFadeIn = false;
        }
    }
    public IEnumerator CountDown()
    {
        int time = 3;
        CountText.gameObject.SetActive(true);
        for (int i = time; i > 0; i--) 
        {
            time--;
            CountText.text = (time + 1).ToString();
            yield return new WaitForSecondsRealtime(1f);
        }
        CountText.gameObject.SetActive(false);
    }
    private void SkillLocked() 
    {
        var explosion = GameManager.instance.Ball.GetComponent<ActiveExplosion>().IsSkill;
        if (explosion == true) 
            ExplosionIconLocked.gameObject.SetActive(false);

        var damage = GameManager.instance.Ball.GetComponent<ActiveDamage>().IsSkill;
        if (damage == true)
            DamageIconLocked.gameObject.SetActive(false);

        var split = GameManager.instance.Ball.GetComponent<ActiveSplit>().IsSkill;
        if (split == true)
            SplitIconLocked.gameObject.SetActive(false);

        var board = GameManager.instance.Ball.GetComponent<ActiveBoard>().IsSkill;
        if (board == true)
            BoardIconLocked.gameObject.SetActive(false);
    }
    private void SetInterFace()
    {
        var ball = GameManager.instance.Ball.GetComponent<Ball>();
        BallLv.text = ball.ballLevel + " ���� ";
        BallDamage.text = "���ݷ� : "+ ball.ballStat.ballDamage;
        Round.text = GameManager.instance.Round + " ����";
        ReflectCount.text = "���� Ƚ�� : " + GameManager.instance.Ball.GetComponent<Ball>().ballStat.ballReflectCount + "��";
    }
    public void GameOver() 
    {
        GameOverLevelText.text = "���� ���� ��¼�� ���� : " + GameManager.instance.Ball.GetComponent<Ball>().ballLevel;
        GameOverPanel.SetActive(true);
        GameManager.instance.Ball.SetActive(false); 
    }
}
