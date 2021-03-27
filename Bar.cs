using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    Rigidbody2D rb;

    public void RBSet()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private bool isLastBar = false;
    
    public void GravitySet(float grav)
    {
        rb.gravityScale = grav*10;
    }

    // Update is called once per frame
    //void FixedUpdate()
    //{
    //    transform.position = new Vector3(0f, transform.position.y -speed*5, 0f);
    //}




    public void LastBar()
    {
        isLastBar = true;
    }
    public bool IsLastBar()
    {
        if (isLastBar)
        {
            isLastBar = false;
            return !isLastBar;
        }
        else
            return isLastBar;
    }


}
