using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("ÉvÉåÉCÉÑÅ[ÇÃà⁄ìÆê›íË")]
    [SerializeField] float _playerSpeed;

    float _x, _y;
    Rigidbody _rb;
    Vector3 _move;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        _x = Input.GetAxis("Horizontal");
        _y = Input.GetAxis("Vertical");

        _move = transform.right * _x + transform.forward * _y;
        _move.Normalize();

        _rb.MovePosition( _rb.position + _move * _playerSpeed * Time.deltaTime );
    }
}
