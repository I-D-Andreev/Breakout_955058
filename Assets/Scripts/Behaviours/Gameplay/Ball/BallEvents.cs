using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallEvents : MonoBehaviour
{
    public static UnityEvent BallHitsPaddleEvent = new UnityEvent();
    public static UnityEvent BallDiesEvent = new UnityEvent();

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Death"))
        {
            BallDiesEvent.Invoke();
        }
        else if(other.gameObject.CompareTag("Player"))
        {
            BallHitsPaddleEvent.Invoke();
        }
    }
}
