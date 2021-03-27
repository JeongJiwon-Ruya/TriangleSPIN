using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinSelector : MonoBehaviour
{
    public Sprite[] TriangleSkins;
    private int currentSkinsIndex;
    public SpriteRenderer Triangle;
    public GameObject UnlockButton;
    public GameObject GameStartText;

    private void Start()
    {
        PlayerPrefs.SetInt("SKIN_0", 1);
        if (PlayerPrefs.GetInt("SKIN_" + currentSkinsIndex).Equals(0))//0 = 안열림, 1 = 열림
        {
            UnlockButton.SetActive(true);
            GameStartText.SetActive(false);
        }
        else
        {
            UnlockButton.SetActive(false);
            GameStartText.SetActive(true);

        }
        currentSkinsIndex = PlayerPrefs.GetInt("SKIN");
        Triangle.sprite = TriangleSkins[currentSkinsIndex];
    }


    public void UnlockSkinButton()
    {
        if (PlayerPrefs.GetInt("COIN") >= 10)
        {
            PlayerPrefs.SetInt("COIN", PlayerPrefs.GetInt("COIN") - 30);
            PlayerPrefs.SetInt("SKIN_" + currentSkinsIndex, 1);
            UnlockButton.SetActive(false);
            GameStartText.SetActive(true);

            GameObject.Find("CoinText").GetComponent<Text>().text = PlayerPrefs.GetInt("COIN").ToString();
        }
    }

    public void LeftClick()
    {
        if (currentSkinsIndex.Equals(0))
            currentSkinsIndex = TriangleSkins.Length - 1;
        else
            currentSkinsIndex--;
        
        Triangle.sprite = TriangleSkins[currentSkinsIndex];

        if (PlayerPrefs.GetInt("SKIN_" + currentSkinsIndex).Equals(0))//0 = 안열림, 1 = 열림
        {
            UnlockButton.SetActive(true); GameStartText.SetActive(false);

        }
        else
        {
            UnlockButton.SetActive(false); GameStartText.SetActive(true);

        }
    }

    public void RightClick()
    {
        if (currentSkinsIndex.Equals(TriangleSkins.Length - 1))
            currentSkinsIndex = 0;
        else
            currentSkinsIndex++;

        Triangle.sprite = TriangleSkins[currentSkinsIndex];

        if (PlayerPrefs.GetInt("SKIN_" + currentSkinsIndex).Equals(0))//0 = 안열림, 1 = 열림
        {
            UnlockButton.SetActive(true); GameStartText.SetActive(false);

        }
        else
        {
            UnlockButton.SetActive(false); GameStartText.SetActive(true);

        }
    }

    public void SetSkin()
    {
        PlayerPrefs.SetInt("SKIN", currentSkinsIndex);
    }
}
