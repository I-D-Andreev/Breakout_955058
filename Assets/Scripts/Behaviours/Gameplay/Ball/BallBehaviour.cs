using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class BallBehaviour : MonoBehaviour
{
    public static UnityEvent BallDeathEvent = new UnityEvent();
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Death"))
        {
            BallDeathEvent.Invoke();
        }
    }
}
