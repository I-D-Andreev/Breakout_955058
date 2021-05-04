using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTileManager : MonoBehaviour
{
    [SerializeField] private float tilePadding = 0.1f;
    [SerializeField] private float worldPaddingTop = 1.1f;
    [SerializeField] private float worldPaddingSide = 0.3f;
    
    private TileFactory _tileFactory;

    private void Awake()
    {
        Debug.Log("Tutorial tile manager awoken");
        _tileFactory = new TileFactory(tilePadding, worldPaddingTop, worldPaddingSide);
    }

    public TileFactory TileFactory => _tileFactory;
}
