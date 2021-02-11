using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallMovement2D : MonoBehaviour
{
    [SerializeField] private float speed = 1;

    private Vector2 _movementDirection;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        _movementDirection = new Vector2(-1, -1);
        Movement();
    }

    public void Movement()
    {
        _rigidbody.velocity = _movementDirection * speed;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
