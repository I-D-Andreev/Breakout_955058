﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(BoxCollider2D))]
public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    
    private BoxCollider2D _boxCollider;
    private Vector2 _moveDirection;
    private float _leftRightBounds;

    private GameChangeMonitor _gameChangeMonitor;
    private float _firstFrameTime;

    private void Awake()
    {
        _boxCollider = gameObject.GetComponent<BoxCollider2D>();
        float paddleWidth = _boxCollider.bounds.size.x / 2;
        float screenWidth = WorldSize.RelativeWidth();

        _leftRightBounds = screenWidth - paddleWidth;
        _gameChangeMonitor = new GameChangeMonitor();
    }

    // private void OnEnable()
    // {
    //     _firstFrameTime = -1;
    // }

    void Update()
    {
        // if (Math.Abs(_firstFrameTime - (-1)) < 0.1)
        // {
        //     _firstFrameTime = Time.timeSinceLevelLoad;
        //     Debug.Log("Character first frame: " + _firstFrameTime);
        //
        // }
        
        MovePlayer();
    }

    private void MovePlayer()
    {        
        Vector2 toMove = _moveDirection * (speed * Time.deltaTime);
        Vector3 newPos = new Vector3(toMove.x, 0, 0) + transform.position;

        if (Math.Abs(newPos.x) <= _leftRightBounds)
        {
            _gameChangeMonitor.SaveAndMakeGameChange(new PaddlePositionChange(Time.timeSinceLevelLoad - _firstFrameTime, newPos.x, newPos.y), gameObject);
            // transform.position = newPos;
        }
    }

    public void OnMove(InputValue input)
    {
        Vector2 direction = input.Get<Vector2>();
        _moveDirection = new Vector2(direction.x, 0);
    }

}
