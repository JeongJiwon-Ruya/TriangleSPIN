using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPopupManager : MonoBehaviour
{
    public Animator anim;

    // Start is called before the first frame update
    

    IEnumerator PopupAnim()
    {
        
        anim.SetTrigger("BtnClick");
        
        Debug.Log(Time.timeScale);
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("IntroScene");
    }

    public void GoMain()
    {
        StartCoroutine(PopupAnim());
    }
}
