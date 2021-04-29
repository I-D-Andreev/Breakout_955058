using UnityEngine;
using UnityEngine.EventSystems;

public class TileBehaviour2D : MonoBehaviour
{
    private int numStrikesToDisappear = 1;
    private int numStrikesLeft = 1;

    public void OnCollisionExit2D(Collision2D other)
    {
        numStrikesLeft--;
        if (numStrikesLeft == 0)
        {
            Destroy(gameObject);
        }
    }

    public int NumStrikesToDisappear
    {
        get => numStrikesToDisappear;
        set
        {
            numStrikesToDisappear = value;
            numStrikesLeft = numStrikesToDisappear;
            // numStrikesChanged() event to change tile colour; or do a numStrikes class
        }
    }
}
