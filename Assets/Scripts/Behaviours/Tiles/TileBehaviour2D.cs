using System;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class TileDestroyEvent : UnityEvent<int> {}


public class TileBehaviour2D : MonoBehaviour
{
    public static TileDestroyEvent TileDestroyEvent = new TileDestroyEvent();
    
    private int _numStrikesToDisappear = 1;
    private int _numStrikesLeft = 1;
    
    public void OnCollisionExit2D(Collision2D other)
    {
        NumStrikesLeft--;
        if (NumStrikesLeft == 0)
        {
            TileDestroyEvent.Invoke(_numStrikesToDisappear);
            Destroy(gameObject);
        }
    }

    public int NumStrikesToDisappear
    {
        get => _numStrikesToDisappear;
        set
        {
            _numStrikesToDisappear = value;
            NumStrikesLeft = _numStrikesToDisappear;
            // numStrikesChanged() event to change tile colour; or do a numStrikes class
        }
    }

    public int NumStrikesLeft
    {
        get => _numStrikesLeft;
        set
        {
            _numStrikesLeft = value;
            // Call NumStrikesChanged (value)
        }
    }
}
