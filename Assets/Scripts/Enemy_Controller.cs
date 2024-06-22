using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float minX, maxX, minY, maxY;
    [SerializeField] private Transform movePoints;

    private int _randomPos;

    [SerializeField] private float _time;

    private float _currentTime;
    void Start()
    {
        movePoints.position = new Vector2(
            Random.Range(minX, maxX),
            Random.Range(minY, maxY));
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            movePoints.position,
            moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, movePoints.position) < 0.2f)
        {
            if (_currentTime <= 0)
            {
                movePoints.position = new Vector2(Random.Range(minX, maxX),
                    Random.Range(minY, maxY));

                _currentTime = _time;
            }
            else
            {
                _currentTime -= Time.deltaTime;
            }
        }
    }
}
