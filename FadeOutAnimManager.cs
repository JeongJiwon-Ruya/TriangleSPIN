using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutAnimManager : MonoBehaviour
{
    public Text ScoreText;
    public Text Left_RightBox;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fade());
    }

    public IEnumerator Fade()
    {
        float time = 0f;

        Color fadeColor = Left_RightBox.color;

        
        while (fadeColor.a < 1f)
        {

            time += Time.deltaTime / 0.9f;
            fadeColor.a = Mathf.Lerp(0f, 1f, time);
            Left_RightBox.color = fadeColor;
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        time = 1f;
        while (fadeColor.a > 0f)
        {

            time -= Time.deltaTime / 0.9f;
            fadeColor.a = Mathf.Lerp(0f, 1f, time);
            Left_RightBox.color = fadeColor;
            yield return null;
        }

        Color ScoreFadeColor = ScoreText.color;
        float t_time = 0f;

        while (ScoreFadeColor.a < 1f)
        {

            t_time += Time.deltaTime / 0.5f;
            ScoreFadeColor.a = Mathf.Lerp(0f, 1f, t_time);
            ScoreText.color = ScoreFadeColor;
            yield return null;
        }

        Left_RightBox.gameObject.SetActive(false);
    }

}
