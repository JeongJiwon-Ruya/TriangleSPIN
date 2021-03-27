using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MoveTriangle : MonoBehaviour
{
    private ColorState state;
    public Sprite[] TriangleSkin;

    public Button left;
    public Button right;
    public GameObject triangle;

    public Animator anim;

    private bool isCycling = false;

    public AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        state = ColorState.RED;

        triangle.GetComponent<SpriteRenderer>().sprite = TriangleSkin[PlayerPrefs.GetInt("SKIN")];

        left.onClick.AddListener(LeftButtonClick);
        right.onClick.AddListener(RightButtonClick);
    }

    IEnumerator VibeTriangle()
    {
        float time = 0f;
        var wait = new WaitForSeconds(Time.deltaTime);
        Vector3 myPoint = triangle.transform.position;
        while(time < 0.06f)
        {
            triangle.transform.position = Random.insideUnitSphere * 0.1f + myPoint;
            time += Time.deltaTime;
            yield return wait;
        }
        triangle.transform.position = myPoint;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == state.ToString())
        {
            audio.Play();
            StartCoroutine(VibeTriangle());
            GameController.Instance.ScorePlus();
            if (other.gameObject.GetComponent<Bar>().IsLastBar())
                GameController.Instance.Nice();
            other.gameObject.SetActive(false);
        }
        else
        {
            GameController.Instance.GameOver();
        }
    }

    public IEnumerator Move(bool LorR) //true면 왼쪽회전 false면 오른쪽회전
    {
        isCycling = true;
        var wait = new WaitForSeconds(Time.deltaTime);
        float z = triangle.transform.rotation.z;
        /*
         * 
        if (LorR)//왼쪽 회전
        {
            if (state.Equals(ColorState.RED))
            {
                while (triangle.transform.eulerAngles.z <= 120)
                {
                    triangle.transform.Rotate(0f, 0f, 8f);
                    yield return wait;
                }
                triangle.transform.rotation = Quaternion.Euler(0f, 0f, 120f);
            }
            else if (state.Equals(ColorState.GREEN))
            {
                while (triangle.transform.eulerAngles.z <= 240)
                {
                    triangle.transform.Rotate(0f, 0f, 8f);
                    yield return wait;
                }
                triangle.transform.rotation = Quaternion.Euler(0f, 0f, 240f);
     
            }
            else if (state.Equals(ColorState.BLUE))


            {
                while (triangle.transform.eulerAngles.z <= 351)
                {
                    triangle.transform.Rotate(0f, 0f, 8f);
                    yield return wait;
                }
                triangle.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }

        }
        else if (!LorR)
        {

            if (state.Equals(ColorState.RED))
            {
                triangle.transform.rotation = Quaternion.Euler(0f, 0f, 359f);
                while (triangle.transform.eulerAngles.z >= 240)
                {

                    triangle.transform.Rotate(0f, 0f, -8f);
                    yield return wait;
                }
                triangle.transform.rotation = Quaternion.Euler(0f, 0f, 240f);
            }
            else if (state.Equals(ColorState.GREEN))
            {
                while (triangle.transform.eulerAngles.z > 9f)
                {
                    triangle.transform.Rotate(0f, 0f, -8f);
                    yield return wait;
                }
                triangle.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

            }
            else if (state.Equals(ColorState.BLUE))
            {
                while (triangle.transform.eulerAngles.z >= 120)
                {
                    triangle.transform.Rotate(0f, 0f, -8f);
                    yield return wait;
                }
                triangle.transform.rotation = Quaternion.Euler(0f, 0f, 120f);
            }
        }
       
        */
        isCycling = false;
        yield return wait;
    }

    public void LeftButtonClick()
    {
        if (isCycling) return;
        else
        {
            if (state.Equals(ColorState.RED))
            {
                //        StartCoroutine(Move(true));
                anim.SetTrigger("Red_to_Green");
                state = ColorState.GREEN;
            }
            else if (state.Equals(ColorState.GREEN))
            {
                //       StartCoroutine(Move(true));
                anim.SetTrigger("Green_to_Blue");
                state = ColorState.BLUE;
            }
            else if (state.Equals(ColorState.BLUE))
            {
                //       StartCoroutine(Move(true));
                anim.SetTrigger("Blue_to_Red");
                state = ColorState.RED;
            }
        }
    }
    public void RightButtonClick()
    {
        if (isCycling) return;
        else
        {
            if (state.Equals(ColorState.RED))
            {
                //       StartCoroutine(Move(false));
                anim.SetTrigger("Red_to_Blue");
                state = ColorState.BLUE;
            }
            else if (state.Equals(ColorState.BLUE))
            {
                //       StartCoroutine(Move(false));
                anim.SetTrigger("Blue_to_Green");
                state = ColorState.GREEN;
            }
            else if (state.Equals(ColorState.GREEN))
            {
                //       StartCoroutine(Move(false));
                anim.SetTrigger("Green_to_Red");
                state = ColorState.RED;
            }

        }
    }
  
}
