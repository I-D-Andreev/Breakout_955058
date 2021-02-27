using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehaviour2D : MonoBehaviour
{
    private void OnCollisionExit2D(Collision2D other)
    {
        Debug.Log("Collision Exit");
        Destroy(gameObject);
    }
}
