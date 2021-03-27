using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public Button GameStart;
    public SpriteRenderer triangle;
    public Text Coins;
    public SkinSelector skinSelector;
    public Text BestScore;

    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        Application.targetFrameRate = 240;
        GameStart.onClick.AddListener(StartButtonClick);
        Coins.text = PlayerPrefs.GetInt("COIN").ToString();
        BestScore.text = "Best\n" + PlayerPrefs.GetInt("HIGHSCORE").ToString();
    }

    void StartButtonClick()
    {
        audio.Play();
        skinSelector.SetSkin();
        GameStart.GetComponent<Animator>().SetTrigger("Click");
        StartCoroutine(fadeoutplay());
    }
   
    
    IEnumerator fadeoutplay()
    {
        var wait = new WaitForSeconds(Time.deltaTime);
        while (triangle.transform.rotation.eulerAngles.z < 179)
        {
            triangle.transform.rotation = Quaternion.Euler(0, -7.8f, Mathf.Lerp(triangle.transform.rotation.eulerAngles.z,359, Time.deltaTime * 4));
            yield return wait;

        }
        triangle.transform.rotation = Quaternion.Euler(0, 0, -180);

        while (triangle.transform.rotation.eulerAngles.z < 355)
        {
            triangle.transform.rotation = Quaternion.Euler(0, -7.8f, Mathf.Lerp(triangle.transform.rotation.eulerAngles.z, 400, Time.deltaTime * 4));
            yield return wait;
        }
        triangle.transform.rotation = Quaternion.Euler(0, 0, 0);
        yield return null;
        SceneManager.LoadScene("GameScene");
    }
}
