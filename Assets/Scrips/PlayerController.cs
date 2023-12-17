using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TreeEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Vector3 direccion;
    public float gravity = -9.8f;
    public float stregth = 5f;
    private int score = 0;
    public TextMeshProUGUI scoreText;
    public GameObject perdistePanel;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)|| Input.GetMouseButtonDown(0))
        {
            direccion = Vector2.up*stregth;
        }
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began) 
            {
                direccion = Vector2.up*stregth;
            }
        }
        direccion.y += gravity*Time.deltaTime;
        transform.position  += direccion * Time.deltaTime;
    }
    private void Start()
    {
        if (perdistePanel != null)
        {
            perdistePanel.SetActive(false); // desactiva el panel al inicio
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Limites"))
        {
            Debug.Log("Te pasaste,We");
        }
        if (other.gameObject.CompareTag("Puntos"))
        {
            IncrementarPuntaje();
            Debug.Log("Puntos: " + score);
        }
    }

    private void IncrementarPuntaje()
    {
        score++;
        if (scoreText != null)
        {
            scoreText.text = "Puntaje: " + score;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tubos"))
        {
            MostrarPerdistePanel();

        }
    }
    private void MostrarPerdistePanel()
    {
        if (perdistePanel != null)
        {
            perdistePanel.SetActive(true); // activa el panel de "perdiste"
        }
        Destroy(gameObject); // Destruye el jugador
        Time.timeScale = 0f;
        Debug.Log("Perdiste papu");
    }
}