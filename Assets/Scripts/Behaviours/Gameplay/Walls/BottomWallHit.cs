using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEngine.Events;

public class BottomWallHitEvent : UnityEvent<GameObject> { }

public class BottomWallHit : MonoBehaviour
{
    public static BottomWallHitEvent BottomWallHitEvent = new BottomWallHitEvent();

    public void OnCollisionEnter2D(Collision2D other)
    {
        BottomWallHitEvent.Invoke(other.gameObject);
    }
}
