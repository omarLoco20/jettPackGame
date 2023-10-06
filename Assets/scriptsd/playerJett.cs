using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class playerJett : MonoBehaviour
{
    // Start is called before the first frame update
    public float force;
    public int life;
    public Sprite spray;
    float collDawn = 0;
    public float forceIntervalo;
    Rigidbody2D rb;
    int coins;
    public GameObject panelLose;
    public TextMeshProUGUI lifeText;

    public TextMeshProUGUI coinsText;
    public scriptablePlayer sp;
    public ScriptableSelector playerSeleccionado;

    SpriteRenderer spriteRender;
    public GameObject jett;
    bool sePropulsa=false;
    private void Awake()
    {
        Time.timeScale = 1;
        force = playerSeleccionado.force;
        life = playerSeleccionado.life;
        spriteRender = GetComponent<SpriteRenderer>();
        spriteRender.sprite = playerSeleccionado.character;
        lifeText.text = "Life: " + life;
        // transform.rotation = playerSeleccionado.rotacion;
        if (playerSeleccionado.cambiarFlip)
        {
            spriteRender.flipX=true;
        }

    }
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

                  //  jett.SetActive(true);
                    rb.AddForce(Vector2.up * force , ForceMode2D.Impulse);
                    collDawn = 0;
                    
                }
                collDawn = collDawn + Time.deltaTime;
                print(collDawn);
            }


        }

        if (Input.GetKey("w")|| Input.GetKey(KeyCode.UpArrow))
        {
            sePropulsa = true;
           // jett.SetActive(true);
            if (collDawn >= forceIntervalo)
            {
                

                rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
                collDawn = 0;

            }
            collDawn = collDawn + Time.deltaTime;
            print(collDawn);
        }
        else
        {
            //  jett.SetActive(false);
            sePropulsa = false;

        }
        jett.SetActive(sePropulsa);


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
            life--;
            lifeText.text = "Life: " + life;
            if (life <= 0)
            {
                
                panelLose.SetActive(true);
                Time.timeScale = 0;
            }
            
        }
    }


}
