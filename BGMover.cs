using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMover : MonoBehaviour
{
   

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(0, -0.03f, 0);
        if (transform.position.y < -18)
            transform.position = new Vector3(0, 24.8f, 0);
    }
}
