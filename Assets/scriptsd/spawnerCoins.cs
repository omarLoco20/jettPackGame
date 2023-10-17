using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerCoins : MonoBehaviour
{
    public GameObject coin1;
    public GameObject coin2;
    public List<GameObject> listaCoinsGroup;
    GameObject groupCoin;

    public Vector2 posicionPartida;
    public float yMin;
    public float yMax;

    private void Awake()
    {
        // Inicializar la lista del pool
        listaCoinsGroup = new List<GameObject>();

        // Crear los enemigos iniciales y agregarlas al pool
        for (int i = 0; i < 10; i++)
        {
            if (i < 5)
            {
                groupCoin = Instantiate(coin1);
            }
            else if (i >= 5)
            {
                groupCoin = Instantiate(coin2);
            }

            groupCoin.SetActive(false); // Desactivar la bala para que no sea visible ni interaccione
            listaCoinsGroup.Add(groupCoin);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("mandarCoin", 0,5 );
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void mandarCoin()
    {

        if (listaCoinsGroup.Count > 0)
        {

            float randY = Random.Range(yMin, yMax);
            posicionPartida.y = randY;

            listaCoinsGroup.RemoveAt(0);
            listaCoinsGroup[0].transform.position = posicionPartida;
            listaCoinsGroup[0].SetActive(true);

        }


    }

    public void devolverEnemy(GameObject enemy)
    {
        enemy.SetActive(false);
        listaCoinsGroup.Add(enemy);

    }
}
