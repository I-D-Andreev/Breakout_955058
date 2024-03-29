﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField] private float tilePadding = 0.1f;
    [SerializeField] private float worldPaddingTop = 0.5f;
    [SerializeField] private float worldPaddingSide = 0.3f;
    
    
    private int _tilesCount;
    private TileFactory _tileFactory;

    
    private void Awake()
    {
        _tileFactory = new TileFactory(tilePadding, worldPaddingTop, worldPaddingSide);
        TileBehaviour.TileDestroyEvent.AddListener(TilesLeft);
    }

    private void Start()
    {
        _tilesCount = _tileFactory.CreateTiles();
    }

    private void TilesLeft(TileBehaviour _)
    {
        _tilesCount--;
        if (_tilesCount <= 0)
        {
            _tilesCount = _tileFactory.CreateTiles();
        }
    }

}
