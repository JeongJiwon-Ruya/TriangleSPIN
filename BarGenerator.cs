using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarGenerator : MonoBehaviour
{
    public GameObject[] bars;
    // Start is called before the first frame update
    private void Awake()
    {
        GenBar();
    }

    void Start()
    {
        StartCoroutine(Generator());
    }


    public IEnumerator Generator()
    {
        int phase = 1;
        int barCount = 0;
        float speed = 0f;
        float term = 0f;

        yield return new WaitForSeconds(2.0f);

        while (GameController.Instance.GetState().Equals(GameState.PLAY))
        {
            if (phase < 3)
            {
                barCount = Random.Range(2, 6);
                speed = 0.03f;
                term = 0.8f;
            }//18
            else if (3 <= phase && phase < 6)
            {
                barCount = Random.Range(5, 8);
                speed = 0.04f;
                term = 0.7f;
            }//18+24   42
            else if (6 <= phase && phase < 9)
            {
                barCount = Random.Range(7, 13);
                speed = 0.055f;
                term = 0.69f;
            }
            else if (9 <= phase && phase < 12)
            {
                barCount = Random.Range(8, 14);
                speed = 0.065f;
                term = 0.68f;
            }
            else if (12 <= phase && phase < 15)
            {
                barCount = Random.Range(9, 13);
                speed = 0.075f;
                term = 0.65f;
            }
            else if (15 <= phase && phase < 18)
            {
                barCount = Random.Range(10, 15);
                speed = 0.087f;
                term = 0.64f;
            }
            else if (18 <= phase && phase < 21)
            {
                barCount = Random.Range(10, 15);
                speed = 0.089f;
                term = 0.63f;
            }
            else if (21 <= phase && phase < 24)
            {
                barCount = Random.Range(11, 15);
                speed = 0.09f;
                term = 0.61f;
            }
            else if (24 <= phase && phase < 29)
            {
                barCount = Random.Range(11, 15);
                speed = 0.092f;
                term = 0.60f;
            }
            else if (29 <= phase)
            {
                barCount = Random.Range(11, 15);
                speed = 0.095f;
                term = 0.59f;
            }

            yield return StartCoroutine(GenerateBar(barCount, speed, term));

            phase++;

            yield return new WaitForSeconds(3f);

        }

        yield return null;
    }

    public Transform BarBox;
    void GenBar()
    {
        for (int i = 1; i < 30; i++)
        {
            GameObject newbars = GameObject.Instantiate(bars[i % 3]);
            newbars.GetComponent<Bar>().RBSet();
            newbars.gameObject.SetActive(false);
            newbars.transform.SetParent(BarBox.transform);
        }
    }
    public IEnumerator GenerateBar(int _barCount, float _speed, float _term)
    {
        var wait = new WaitForSeconds(_term);

        int ranChild;
        int ranAngle;
        for (int i = 0; i < _barCount; i++)
        {
            do
            {
                ranChild = Random.Range(1, 29);
            } while (BarBox.GetChild(ranChild).gameObject.activeInHierarchy);

            BarBox.GetChild(ranChild).gameObject.SetActive(true);
            ranAngle = Random.Range(-25, 25);
            BarBox.GetChild(ranChild).transform.position = new Vector3(0f, 15f, 0f);
            BarBox.GetChild(ranChild).transform.rotation = Quaternion.Euler(0f, 0f, ranAngle);
            BarBox.GetChild(ranChild).GetComponent<Bar>().GravitySet(_speed);
            if (i.Equals(_barCount - 1))
                BarBox.GetChild(ranChild).GetComponent<Bar>().LastBar();
            yield return wait;
        }

    }
}
