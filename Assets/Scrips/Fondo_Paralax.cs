using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fondo_Paralax : MonoBehaviour
{
    [SerializeField]
    private Vector2 velocidadMov;
    private Vector2 offset;
    private Material material;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }
    void Update()
    {
        offset = velocidadMov*Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
