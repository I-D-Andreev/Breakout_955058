using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Tile
{
    private GameObject _tile;
    
    private float Width { get; }
    private float Height { get; }
    private Vector2 Position { get;  }

    public Tile(Vector2 position)
    {
        GameObject tilePrefab = Resources.Load<GameObject>("Prefabs/Tile");
        Position = position;
        _tile = GameObject.Instantiate(tilePrefab, new Vector3(Position.x, Position.y, 0), Quaternion.identity);
    
        Debug.Log("Tile is " + _tile);
        Debug.Log("Tile transform is " + _tile.transform);

        Vector3 sizes = _tile.transform.localScale;
        Vector2 sizeScale = _tile.GetComponent<SpriteRenderer>().size; 
        
        Width = sizes.x * sizeScale.x;
        Height = sizes.y * sizeScale.y;
        
        Debug.Log("Height is: " + Height);
        Debug.Log("Width is: " + Width);
    }
}
