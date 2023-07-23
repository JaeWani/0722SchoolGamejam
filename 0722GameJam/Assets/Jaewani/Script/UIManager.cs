using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header ("페이드 인 아웃")]
    public GameObject Fade;
    public CanvasGroup FadecanvasGroup;

    [Header("스킬 아이콘")]
    public Image ExplosionIcon;
    public Image ExplosionIconLocked;

    public Image DamageIcon;
    public Image DamageIconLocked;

    public Image SplitIcon;
    public Image SplitIconLocked;

    public Image BoardIcon;
    public Image BoardIconLocked;

    [Header ("카운트 다운")]
    public Text CountText;
    [Header("인터페이스")]
    public Text BallLv;
    public Text BallDamage;
    public Text Round;
    public Text ReflectCount;
    [Header("게임 오버 패널")]
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
        BallLv.text = ball.ballLevel + " 레벨 ";
        BallDamage.text = "공격력 : "+ ball.ballStat.ballDamage;
        Round.text = GameManager.instance.Round + " 라운드";
        ReflectCount.text = "남은 횟수 : " + GameManager.instance.Ball.GetComponent<Ball>().ballStat.ballReflectCount + "번";
    }
    public void GameOver() 
    {
        GameOverLevelText.text = "님의 생전 개쩌는 레벨 : " + GameManager.instance.Ball.GetComponent<Ball>().ballLevel;
        GameOverPanel.SetActive(true);
        GameManager.instance.Ball.SetActive(false); 
    }
}
