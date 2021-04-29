using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField] private float tilePadding = 0.1f;
    [SerializeField] private float worldPaddingTop = 0.5f;
    [SerializeField] private float worldPaddingSide = 0.3f;
    
    
    private List<GameObject> tiles;
    private TileFactory tileFactory;

    
    private void Awake()
    {
        tileFactory = new TileFactory(tilePadding, worldPaddingTop, worldPaddingSide);
        tiles = tileFactory.CreateTiles(TileFactory.TileFormation.Rectangle);
    }

}
