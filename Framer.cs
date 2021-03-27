using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Framer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 240;
    }

    public void TimeScaleReset()
    {
        Time.timeScale = 1f;
    }


}
