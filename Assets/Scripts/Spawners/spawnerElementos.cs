using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerElementos : MonoBehaviour
{
    public GameObject enemyRayo;
    public GameObject monedas;
    public List<GameObject> listaOvnisYBasura;
    GameObject enemy;

    public Vector2 posicionPartida;
    public float yMin;
    public float yMax;

    private void Awake()
    {
        // Inicializar la lista del pool
        listaOvnisYBasura = new List<GameObject>();

        // Crear los enemigos iniciales y agregarlas al pool
        for (int i = 0; i < 20; i++)
        {
            if (i < 10)
            {
                enemy = Instantiate(enemyRayo);
            }
            else if (i >= 10)
            {
                enemy = Instantiate(monedas);
            }

            enemy.SetActive(false); // Desactivar la bala para que no sea visible ni interaccione
            listaOvnisYBasura.Add(enemy);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("mandarEnemy", 0, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void mandarEnemy()
    {

        if (listaOvnisYBasura.Count > 0)
        {

            float randY = Random.Range(yMin, yMax);
            posicionPartida.y = randY;

            listaOvnisYBasura.RemoveAt(0);
            listaOvnisYBasura[0].transform.position = posicionPartida;
            listaOvnisYBasura[0].SetActive(true);

        }


    }

    public void devolverEnemy(GameObject enemy)
    {
        enemy.SetActive(false);
        listaOvnisYBasura.Add(enemy);

    }
}
