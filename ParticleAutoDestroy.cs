using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAutoDestroy : MonoBehaviour
{
    void OnEnable()
    {
        StartCoroutine(CoCheckAlive());
    }

    IEnumerator CoCheckAlive()
    {
        yield return new WaitForSeconds(0.3f);
        gameObject.SetActive(false);
        yield return null;
 
  
    }
}
