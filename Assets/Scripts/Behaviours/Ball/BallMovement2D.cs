using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class BallMovement2D : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    [SerializeField] private Vector2 _movement = new Vector2(-1, 1);
    private Rigidbody2D _rigidbody2D;
    
    
    private void Awake()
    {
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _rigidbody2D.velocity = _movement * speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision");
    }
}
