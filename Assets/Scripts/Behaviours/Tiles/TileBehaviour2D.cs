using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehaviour2D : MonoBehaviour
{
    private int _numStrikesToDisappear = 1;
    private int _numStrikesLeft = 1;
    private void OnCollisionExit2D(Collision2D other)
    {
        _numStrikesLeft--;
        if (_numStrikesLeft == 0)
        {
            Destroy(gameObject);
        }
    }

    public int NumStrikesToDisappear
    {
        get => _numStrikesToDisappear;
        set { 
            _numStrikesToDisappear = value;
            _numStrikesLeft = _numStrikesToDisappear;
            // numStrikesChanged(); or do a numStrikes class   
        }
    }
}
