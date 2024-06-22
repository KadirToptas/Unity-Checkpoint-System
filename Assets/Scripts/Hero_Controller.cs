using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero_Controller : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Vector2[] _checkPoints;
    public static Vector2 _lastTransform;
    [SerializeField] private float moveSpeed;

    private Vector2 _move;
    void Start()
    {
        transform.position = _lastTransform;
    }

    
    void Update()
    {
        _move.x = Input.GetAxisRaw("Horizontal");
        _move.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if (_move.x != 0 || _move.y != 0)
        {
            rb.velocity = new Vector2(
                _move.x * moveSpeed,
                _move.y * moveSpeed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
