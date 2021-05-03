using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class BallMovement2D : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    [SerializeField] private Vector2 movement = new Vector2(-1, 1);
    private Rigidbody2D _rigidbody2D;
    private GameChangeMonitor _gameChangeMonitor;
    private float _firstFrameTime;
    
    private void Awake()
    {
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        _gameChangeMonitor = new GameChangeMonitor();
    }

    private void Start()
    {
        _rigidbody2D.velocity = movement * speed;
    }

    // private void OnEnable()
    // {
    //     _firstFrameTime = -1;
    // }

    private void Update()
    {
        // if (Math.Abs(_firstFrameTime - (-1)) < 0.1)
        // {
        //     _firstFrameTime = Time.timeSinceLevelLoad;
        //     Debug.Log("Ball first frame: " + _firstFrameTime);
        //
        // }
        
        if (_rigidbody2D.velocity.x == 0)
        {
            _rigidbody2D.velocity = new Vector2(movement.x * speed, _rigidbody2D.velocity.y);
        }
        
        if (_rigidbody2D.velocity.y == 0)
        {
            _rigidbody2D.velocity = new Vector2( _rigidbody2D.velocity.x, movement.y * speed);
        }

        var position = gameObject.transform.position;
        _gameChangeMonitor.SaveGameChange(new BallPositionChange(Time.timeSinceLevelLoad - _firstFrameTime, position.x, position.y));
    }
}
