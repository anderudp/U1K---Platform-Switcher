using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    public Vector2 MoveDirection = Vector2.zero;
    public float speed = 1f;
    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startPos + new Vector3(
            Mathf.Sin(Time.time * speed) * MoveDirection.x, 
            Mathf.Sin(Time.time * speed) * MoveDirection.y,
            0f);
    }
}
