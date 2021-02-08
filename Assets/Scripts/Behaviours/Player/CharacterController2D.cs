using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    
    private Rigidbody2D _rigidBody;

    private void Awake()
    {
        _rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
    }

    public void OnMove(InputValue input)
    {
        Move(input.Get<Vector2>());
    }

    public void Move(Vector2 direction)
    {
        Vector2 temp = _rigidBody.velocity;
        temp.x = direction.x * speed;
        _rigidBody.velocity = temp;
    }
}
