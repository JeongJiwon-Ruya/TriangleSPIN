using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private static GameController _instance;
    public static GameController Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(GameController)) as GameController;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Pause();
        }
    }

    private void Start()
    {
        Screen.SetResolution(1080, 2200, true);
        audio = GetComponent<AudioSource>();
    
    }

    private void Awake()
    {


        if (_instance == null)
        {
            _instance = this;
        }
        // 인스턴스가 존재하는 경우 새로생기는 인스턴스를 삭제한다.
        else if (_instance != this)
        {
            Destroy(gameObject);
        }

        // 아래의 함수를 사용하여 씬이 전환되더라도 선언되었던 인스턴스가 파괴되지 않는다.
     //   DontDestroyOnLoad(gameObject);
    }

    public GameState state;
    public GameObject GameOverPopup;
    public Text scoreTextInPopup;
    public Text scoreTextInGame;
    public Text nictText;
    public GameObject Effect;
    public GameObject PausePopup;
    public BoxCollider2D TriangleTrigger;
    public Animator ScoreAnim;
    public Animator CoinAnim;
    public GoogleAdsManager gads;

    AudioSource audio;

    private int score = 0;
    void Pause()
    {
        Time.timeScale = 0f;
        PausePopup.SetActive(true);
    }
    public GameState GetState()
    {
        return state;
    }

    public void SetState(GameState _newState)
    {
        state = _newState;
    }

    public void GameOver()
    {
        TriangleTrigger.enabled = false;

        this.SetState(GameState.GAMEOVER);
        gads.ShowInterstitial();
        if (PlayerPrefs.GetInt("HIGHSCORE") < score)
        {
            PlayerPrefs.SetInt("HIGHSCORE", score);
            scoreTextInPopup.text = "New HighScore !\n" + score.ToString();
        }
        else
        {
            scoreTextInPopup.text = "Score : " + score.ToString() + "\nHighScore : " + PlayerPrefs.GetInt("HIGHSCORE");
        }
        GameOverPopup.SetActive(true);
    }

    public void ScorePlus()
    {
        ScoreAnim.SetTrigger("Plus");
        score++;
        Effect.SetActive(true);
        scoreTextInGame.text = score.ToString();
    }


    public void Nice()
    {
        if(Random.Range(0,10) < 4)
        {
            audio.Play();
            PlayerPrefs.SetInt("COIN", PlayerPrefs.GetInt("COIN") + 1);
            CoinAnim.SetTrigger("GET");
        }
        StartCoroutine(NicePopup());
    }

    IEnumerator NicePopup()
    {
        nictText.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        nictText.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        nictText.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        nictText.gameObject.SetActive(false);
    }

}
