using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TileFactory
{
    private static GameObject _tilePrefab;
    
    private float _tileWidthPadded;
    private float _tileHeightPadded;

    private float _startWidth;
    private float _endWidth;
    
    private float _startHeight;
    private float _endHeight;

    
    public enum TileFormation
    {
        Rectangle,
    }

    public TileFactory(float tilePadding, float worldPaddingTop, float worldPaddingSide) : this("Prefabs/Tile", tilePadding,  worldPaddingTop, worldPaddingSide) { }
    public TileFactory(string prefabPath, float tilePadding, float worldPaddingTop, float worldPaddingSide)
    {
        _tilePrefab = Resources.Load<GameObject>(prefabPath);
        (float tileWidth, float tileHeight) = CalculateWidthHeight();
        
        _tileWidthPadded = tileWidth + tilePadding;
        _tileHeightPadded = tileHeight + tilePadding;

        // Usable world coordinates
        _startWidth = -(WorldSize.RelativeWidth() - (_tileWidthPadded/2) - worldPaddingSide);
        _endWidth = Math.Abs(_startWidth);
        
        _startHeight = WorldSize.RelativeHeight() - _tileHeightPadded/2 - worldPaddingTop;
        _endHeight = 0f; // middle of screen
    }


    
    private static (float,float) CalculateWidthHeight()
    {

        Vector3 sizes = _tilePrefab.transform.localScale;
        Vector2 sizesScale = _tilePrefab.GetComponent<SpriteRenderer>().size;

        // (tileWidth, tileHeight)
        return (sizes.x * sizesScale.x, sizes.y * sizesScale.y);
    }

    public int CreateTiles(TileFactory.TileFormation tileFormation)
    {
        switch (tileFormation)
        {
            case TileFormation.Rectangle:
                return CreateTilesRect();
        }

        return 0;
    }

    // Create Tiles in a Rectangle
    private int CreateTilesRect()
    {
        float totalWidth = _endWidth - _startWidth;
        float totalHeight = Math.Abs(_endHeight - _startHeight);
        
        int possibleColumns = (int)(totalWidth / _tileWidthPadded);
        int possibleRows = (int)(totalHeight / _tileHeightPadded);
        
        // recalculate padding so that tiles are centered
        float widthOffset = (totalWidth - possibleColumns * _tileWidthPadded) /2;
        
        float tilePositionX = _startWidth + widthOffset + _tileWidthPadded/2; // as tiles are rendered from middle
        float tilePositionY = _startHeight;

        int tilesCount = 0;
        for (int i = 0; i < possibleRows; i++)
        {

            for (int j = 0; j < possibleColumns; j++)
            {

                float posX = tilePositionX + j * _tileWidthPadded;
                float posY = tilePositionY - i * _tileHeightPadded;
                
                CreateTile(posX, posY);
                tilesCount++;
            }
        }
        
        Debug.Log("Total tiles: " + tilesCount);

        return tilesCount;
    }

    
    private void CreateTile(float posX, float posY) {
        GameObject.Instantiate(_tilePrefab, new Vector3(posX, posY, 0), Quaternion.identity);
    }

}
