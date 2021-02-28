using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Calculate sizes for walls so that they go around the Camera.
public class CalculateWalls : MonoBehaviour
{
    private float _screenHeight;
    private float _screenWidth;
    private void Awake()
    {
        _screenHeight = WorldSize.RelativeHeight();
        _screenWidth = WorldSize.RelativeWidth();
        
        // Walls
        Transform leftWall = transform.Find("Left");
        Transform rightWall = transform.Find("Right");
        Transform topWall = transform.Find("Top");
        Transform bottomWall = transform.Find("Bottom");
        
        // Verticall Walls
        float verticalWidth = 1;
        float verticalHeight = 2 * _screenHeight;
        
        Vector3 verticalWallSize = new Vector3(verticalWidth, verticalHeight, 1);
        leftWall.localScale = verticalWallSize;
        rightWall.localScale = verticalWallSize;

        float verticalPositionOffset = _screenWidth + (verticalWidth / 2);

        leftWall.position = new Vector3(-verticalPositionOffset, 0, 1);
        rightWall.position = new Vector3(verticalPositionOffset, 0, 1);
        
        // Horizontal Walls
        float horizontalHeight = 1;
        float horizontalWidth = 2 * _screenWidth;

        Vector3 horizontalWallSize = new Vector3(horizontalWidth, horizontalHeight, 1);

        bottomWall.localScale = horizontalWallSize;
        topWall.localScale = horizontalWallSize;
        
        float horizontalPositionOffset = _screenHeight + (verticalWidth / 2);
        bottomWall.position = new Vector3(0, -horizontalPositionOffset, 1);
        topWall.position = new Vector3(0 ,horizontalPositionOffset,  1);
    }
}
