using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TileFactory
{
    private static GameObject tilePrefab;

    // tile sizes
    private static float tileWidth;
    private static float tileHeight;
    private static bool widthHeightInstantiated = false;

    // padding
    private float tilePadding;
    private float worldPaddingTop;
    private float worldPaddingSide;

    public enum TileFormation
    {
        Rectangle,
    }

    public TileFactory(float tilePadding, float worldPaddingTop, float worldPaddingSide) : this("Prefabs/Tile", tilePadding,  worldPaddingTop, worldPaddingSide) { }
    public TileFactory(string prefabPath, float tilePadding, float worldPaddingTop, float worldPaddingSide)
    {
        this.tilePadding = tilePadding;
        this.worldPaddingTop = worldPaddingTop;
        this.worldPaddingSide = worldPaddingSide;

        tilePrefab = Resources.Load<GameObject>(prefabPath);
    }


    public static float TileWidth()
    {
        if (!widthHeightInstantiated)
        {
            CalculateWidthHeight();
        }

        return tileWidth;
    }
    public static float TileHeight()
    {
        if (!widthHeightInstantiated)
        {
            CalculateWidthHeight();
        }

        return tileHeight;
    }
    private static void CalculateWidthHeight()
    {

        Vector3 sizes = tilePrefab.transform.localScale;
        Vector2 sizesScale = tilePrefab.GetComponent<SpriteRenderer>().size;

        tileWidth = sizes.x * sizesScale.x;
        tileHeight = sizes.y * sizesScale.y;

        widthHeightInstantiated = true;
    }

    public List<GameObject> CreateTiles(TileFactory.TileFormation tileFormation)
    {
        switch (tileFormation)
        {
            case TileFormation.Rectangle:
                return CreateTilesRect();
        }

        return new List<GameObject>();
    }

    // Create Tiles in a Rectangle
    private List<GameObject> CreateTilesRect()
    {
        List<GameObject> tiles = new List<GameObject>();

        float tileWidthPadded = TileWidth() + tilePadding;
        float tileHeightPadded = TileHeight() + tilePadding;

        float startWidth = -(WorldSize.RelativeWidth() - (tileWidthPadded/2) - worldPaddingSide);
        float endWidth = Math.Abs(startWidth);

        float startHeight = WorldSize.RelativeHeight() - tileHeightPadded/2 - worldPaddingTop;
        float endHeight = 0f; // middle of screen

        float totalWidth = endWidth - startWidth;
        float totalHeight = Math.Abs(endHeight - startHeight);
        
        int possibleColumns = (int)(totalWidth / tileWidthPadded);
        int possibleRows = (int)(totalHeight / tileHeightPadded);
        
        // recalculate padding so that tiles are centered
        float widthOffset = (totalWidth - possibleColumns * tileWidthPadded) /2;
        
        float tilePositionX = startWidth + widthOffset + tileWidthPadded/2; // as tiles are rendered from middle
        float tilePositionY = startHeight;

        for (int i = 0; i < possibleRows; i++)
        {

            for (int j = 0; j < possibleColumns; j++)
            {

                float posX = tilePositionX + j * tileWidthPadded;
                float posY = tilePositionY - i * tileHeightPadded;
                
                tiles.Add(CreateTile(posX, posY));
            }
        }
        
        Debug.Log("Total tiles: " + tiles.Count);

        return tiles;
    }


    private GameObject CreateTile(float posX, float posY) {
        return GameObject.Instantiate(tilePrefab, new Vector3(posX, posY, 0), Quaternion.identity);
    }

}
