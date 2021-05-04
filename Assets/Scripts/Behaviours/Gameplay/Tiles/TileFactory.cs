using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class TileFactory
{
    private static GameObject _tilePrefab;

    private float _tileWidthPadded;
    private float _tileHeightPadded;

    private float _startWidth;
    private float _startHeight;

    private int _possibleRows;
    private int _possibleColumns;

    // space left if the padded tiles (possibleColumns) do not fully cover the full width
    // e.g. if we have 0.4 tiles left of width
    private float _widthOffset;


    private List<Func<int>> _tileCreationMethods;

    public TileFactory(float tilePadding, float worldPaddingTop, float worldPaddingSide) : this("Prefabs/Gameplay/Tile",
        tilePadding, worldPaddingTop, worldPaddingSide)
    {
    }

    public TileFactory(string prefabPath, float tilePadding, float worldPaddingTop, float worldPaddingSide)
    {
        _tilePrefab = Resources.Load<GameObject>(prefabPath);

        (float tileWidth, float tileHeight) = CalculateWidthHeight();

        _tileWidthPadded = tileWidth + tilePadding;
        _tileHeightPadded = tileHeight + tilePadding;

        // Tiles world coordinates
        _startWidth = -(WorldSize.RelativeWidth() - (_tileWidthPadded / 2) - worldPaddingSide);
        _startHeight = WorldSize.RelativeHeight() - _tileHeightPadded / 2 - worldPaddingTop;

        float endWidth = Math.Abs(_startWidth);
        float endHeight = 0f; // middle of screen
        float totalWidth = endWidth - _startWidth;
        float totalHeight = Math.Abs(endHeight - _startHeight);

        _possibleColumns = (int) (totalWidth / _tileWidthPadded);
        _possibleRows = (int) (totalHeight / _tileHeightPadded);
        _widthOffset = (totalWidth - _possibleColumns * _tileWidthPadded) / 2;

        _tileCreationMethods = new List<Func<int>>
        {
            CreateTilesRect, CreateTilesMosaic, CreateTilesColumns, CreateTilesRandomRect
        };
    }

    public int CreateTiles()
    {
        int index = Random.Range(0, _tileCreationMethods.Count);
        return _tileCreationMethods[index]();
    }


    public int CreateTilesRect()
    {
        float tilePositionX = _startWidth + _widthOffset + _tileWidthPadded / 2; // as tiles are rendered from middle
        float tilePositionY = _startHeight;

        int tilesCount = 0;
        for (int i = 0; i < _possibleRows; i++)
        {
            for (int j = 0; j < _possibleColumns; j++)
            {
                CreateTile(tilePositionX + j * _tileWidthPadded, tilePositionY - i * _tileHeightPadded);
                tilesCount++;
            }
        }

        return tilesCount;
    }

    public int CreateTilesMosaic()
    {
        float tilePositionX = _startWidth + _widthOffset + _tileWidthPadded / 2; // as tiles are rendered from middle
        float tilePositionY = _startHeight;

        int tilesCount = 0;
        for (int i = 0; i < _possibleRows; i++)
        {
            for (int start = i % 2, j = start; j < _possibleColumns; j += 2)
            {
                CreateTile(tilePositionX + j * _tileWidthPadded, tilePositionY - i * _tileHeightPadded);
                tilesCount++;
            }
        }
        
        return tilesCount;
    }

    public int CreateTilesColumns()
    {
        // If the number of possible columns is an even number, we will not fill in the last one.
        // In such a case, offset the tiles with half a tile more.
        float additionalOffset = _possibleColumns % 2 == 0 ? _tileWidthPadded / 2 : 0;

        float tilePositionX =
            _startWidth + _widthOffset + additionalOffset + _tileWidthPadded / 2; // as tiles are rendered from middle
        float tilePositionY = _startHeight;

        int tilesCount = 0;
        for (int i = 0; i < _possibleRows; i++)
        {
            for (int j = 0; j < _possibleColumns; j += 2)
            {
                CreateTile(tilePositionX + j * _tileWidthPadded, tilePositionY - i * _tileHeightPadded);
                tilesCount++;
            }
        }
        
        return tilesCount;
    }

    public int CreateTilesRandomRect()
    {
        float tilePositionX = _startWidth + _widthOffset + _tileWidthPadded / 2; // as tiles are rendered from middle
        float tilePositionY = _startHeight;

        int tilesCount = 0;
        for (int i = 0; i < _possibleRows; i++)
        {
            for (int j = 0; j < _possibleColumns; j++)
            {
                if (Random.value <= 0.5f)
                {
                    // Randomly decide with 50% chance whether to insert a tile.
                    CreateTile(tilePositionX + j * _tileWidthPadded, tilePositionY - i * _tileHeightPadded);
                    tilesCount++;
                }
            }
        }
        
        return tilesCount;
    }

    public void CreateTile(float posX, float posY)
    {
        // We can set Time=0, as the List of GameChanges is in order of time (and previous elements will block).
        // Setting this time to 0 will make Tile Rendering to appear as soon as possible.
        int numStrikesToDisappear = Random.Range(1, 3 + 1);
        GameChangeMonitor.SaveAndMakeGameChange(
            new TileCreateChange(0, posX, posY, numStrikesToDisappear),
            _tilePrefab);
    }


    private static (float, float) CalculateWidthHeight()
    {
        Vector3 sizes = _tilePrefab.transform.localScale;
        Vector2 sizesScale = _tilePrefab.GetComponent<SpriteRenderer>().size;

        // (tileWidth, tileHeight)
        return (sizes.x * sizesScale.x, sizes.y * sizesScale.y);
    }
}