using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UIElements;

public class PipeController : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;
    private void Update()
    {
        Move();
        if(transform.position.x < -5.5f)
        {
            gameObject.SetActive(false);
        }
    }

    private void Move()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
