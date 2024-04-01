using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowMessageOnCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Object: "+gameObject.name+" starts colliding with: "+collision.gameObject.name);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Object: " + gameObject.name + " is colliding with: " + collision.gameObject.name);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Object: " + gameObject.name + " has ended collision with: " + collision.gameObject.name);
    }
}
