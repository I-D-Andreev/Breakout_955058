using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

[RequireComponent(typeof(BoxCollider2D))]
public class BallMovement2D : MonoBehaviour
{
    [SerializeField] private float speed = 1;

    private Vector2 _movementDirection;
    private BoxCollider2D _boxCollider;

    private float _leftRight;
    private float _bottomTop;
    
    
    private void Awake()
    {
        _boxCollider = gameObject.GetComponent<BoxCollider2D>();
        _movementDirection = new Vector2(-1, -1);

        float screenHeight = Camera.main.orthographicSize;
        float screenWidth = screenHeight * Camera.main.aspect;

        _bottomTop = screenHeight - (_boxCollider.size.y / 2);
        _leftRight = screenWidth - (_boxCollider.size.x / 2);
    }

    
    
    // Update is called once per frame
    void Update()
    {
        Vector2 toMove = _movementDirection * (speed * Time.deltaTime);
        Vector3 newPos = new Vector3(toMove.x, toMove.y, 0) + transform.position;

        if (Math.Abs(newPos.y) >= _bottomTop)
        {
            _movementDirection.y *= -1;
        }
        else if (Math.Abs(newPos.x) >= _leftRight)
        {
            _movementDirection.x *= -1;
        }
        else
        {
            transform.position = newPos;
        }
    }
    
    
    public void MoveBall()
    {
        Debug.Log("Set movement: " + _movementDirection);
    }
   
}
