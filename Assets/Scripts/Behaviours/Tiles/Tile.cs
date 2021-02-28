using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Tile
{
    private static GameObject _tilePrefab = Resources.Load<GameObject>("Prefabs/Tile");
    private static float _tileWidth ;
    private static float _tileHeight;
    private static bool _widthHeightInstantiated = false;
    
    
    private GameObject _tile;
    
    private Vector2 Position { get;  }

    public Tile(Vector2 position)
    {
        Position = position;
        _tile = GameObject.Instantiate(_tilePrefab, new Vector3(Position.x, Position.y, 0), Quaternion.identity);
    }

    public static float Width()
    {
        if (!_widthHeightInstantiated)
        {
            CalculateWidthHeight();
        }

        return _tileWidth;
    }
    
    public static float Height()
    {
        if (!_widthHeightInstantiated)
        {
            CalculateWidthHeight();
        }

        return _tileHeight;
    }



    private static void  CalculateWidthHeight()
    {
        
        Vector3 sizes = _tilePrefab.transform.localScale;
        Vector2 sizesScale = _tilePrefab.GetComponent<SpriteRenderer>().size;

        _tileWidth = sizes.x * sizesScale.x;
        _tileHeight = sizes.y * sizesScale.y;
        
        _widthHeightInstantiated = true;
    }
    
}
