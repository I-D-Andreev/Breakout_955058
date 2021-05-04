using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTilesTutorialEvent : TutorialEvent
{
    public override bool TryExecuteEvent()
    {
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");
        foreach (var tile in tiles)
        {
            GameObject.Destroy(tile);
        }

        return true;
    }
}
