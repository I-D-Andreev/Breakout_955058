using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField] private int numberOfTiles = 10;
    [SerializeField] private float tilePadding = 0.06f;
    [SerializeField] private float worldPaddingTop = 1f;
    [SerializeField] private float worldPaddingSide = 1f;
    
    
    private List<Tile> tiles = new List<Tile>();
    
    private void Awake()
    {
        CreateTilesRect();
    }

    private void CreateTilesRect()
    {
  
        float tileWidthPadded = Tile.Width() + tilePadding;
        float tileHeightPadded = Tile.Height() + tilePadding;

        float startWidth = -(WorldSize.RelativeWidth() - (tileWidthPadded/2) - worldPaddingSide);
        float endWidth = Math.Abs(startWidth);

        float startHeight = WorldSize.RelativeHeight() - tileHeightPadded/2 - worldPaddingTop;
        float endHeight = 0f; // middle of screen
        
        Debug.Log("World width: " + WorldSize.RelativeWidth());
        Debug.Log("World height: " + WorldSize.RelativeHeight());
        
        Debug.Log("Start width: " + startWidth);
        Debug.Log("Start height: " + startHeight);
        
        Debug.Log("World padding side: " + worldPaddingSide);
        Debug.Log("World padding top: " + worldPaddingTop);

  

        int possibleColumns = (int)((endWidth - startWidth) / tileWidthPadded);
        int possibleRows = (int)(Math.Abs(endHeight - startHeight) / tileHeightPadded);


        int numTilesCopy = numberOfTiles;
        // recalculate padding so that tiles are centered
        //todo1

        float tilePositionX = startWidth;
        float tilePositionY = startHeight;

        for (int i = 0; i < possibleRows; i++)
        {
            if (numTilesCopy == 0)
            {
                break;
            }

            for (int j = 0; j < possibleColumns; j++)
            {
                if (numTilesCopy == 0)
                {
                    break;
                }

                float posX = tilePositionX + j * tileWidthPadded;
                float posY = tilePositionY - i * tileHeightPadded;
                
                tiles.Add(new Tile(new Vector2(posX, posY)));
                numTilesCopy--;
            }
        }
    }
    
    
}
