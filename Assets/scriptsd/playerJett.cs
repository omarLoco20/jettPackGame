using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class playerJett : MonoBehaviour
{
    // Start is called before the first frame update
    public float force;
    float collDawn = 0;
    public float forceIntervalo;
    Rigidbody2D rb;
    int coins;

    public TextMeshProUGUI coinsText;
    public scriptablePlayer sp;
    void Start()
    {
        coins = sp.coins;

        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("contador", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0)
        {
            // Obtener el primer toque
            Touch touch = Input.GetTouch(0);

            // Verificar si el toque está en curso (es decir, el jugador lo está manteniendo presionado)
            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                if (collDawn >= forceIntervalo)
                {

                    rb.AddForce(Vector2.up * force , ForceMode2D.Impulse);
                    collDawn = 0;
                    
                }
                collDawn = collDawn + Time.deltaTime;
                print(collDawn);
            }


        }

       

    }


    public void contador()
    {

        coins++;
        coinsText.text = "Coins: " + coins;


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "rayo")
        {
            SceneManager.LoadScene("SampleScene");
        }
    }


}
