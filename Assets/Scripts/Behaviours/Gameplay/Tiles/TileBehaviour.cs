using System;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

[System.Serializable]
public class TileDestroyEvent : UnityEvent<TileBehaviour> {}


[RequireComponent(typeof(SpriteRenderer))]
public class TileBehaviour : MonoBehaviour
{
    public static TileDestroyEvent TileDestroyEvent = new TileDestroyEvent();

    private SpriteRenderer _spriteRenderer;
    
    private int _numStrikesToDisappear;
    private int _numStrikesLeft;
 
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        NumStrikesToDisappear = Random.Range(1, 3+1);
        // NumStrikesToDisappear = 1; use for faster debug
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        NumStrikesLeft--;
        if (NumStrikesLeft == 0)
        {
            TileDestroyEvent.Invoke(this);
            Destroy(gameObject);
        }
    }

    public int NumStrikesToDisappear
    {
        get => _numStrikesToDisappear;
        private set
        {
            _numStrikesToDisappear = value;
            NumStrikesLeft = _numStrikesToDisappear;
        }
    }

    private int NumStrikesLeft
    {
        get => _numStrikesLeft;
        set
        {
            _numStrikesLeft = value;
            NumStrikesLeftChanged();
        }
    }

    private void NumStrikesLeftChanged()
    {
        Color color;
        
        switch (NumStrikesLeft)
        {
            case 3:
                color = Color.red;
                break;
            case 2:
                color = Color.yellow;
                break;
            case 1:
                color = Color.green;
                break;
            case 0:
                color = Color.white;
                break;
            default:
                NumStrikesLeft = 1;
                return;
        }

        _spriteRenderer.color = color;
    }
}
