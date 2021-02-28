using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField] private int numberOfTiles = 10;
    private List<Tile> tiles = new List<Tile>();
    
    private void Awake()
    {
        
        CreateTiles();
    }

    private void CreateTiles()
    {
        Tile tile = new Tile(new Vector2(-5, 3));
        tiles.Add(tile);
    }
    
    
}
