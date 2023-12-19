using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerEnemys : MonoBehaviour
{
    public GameObject r1;
    public GameObject r2;
    public GameObject r3;
    public GameObject r4;
    public List<GameObject> rayos;
    GameObject enemy;

    public Vector2 posicionPartida;
    public float yMin;
    public float yMax;

    private void Awake()
    {
        // Inicializar la lista del pool
        rayos = new List<GameObject>();

        // Crear los enemigos iniciales y agregarlas al pool
        for (int i = 0; i < 20; i++)
        {
            if (i < 5)
            {
                enemy = Instantiate(r1);
            }
            else if (i > 4&&i<11)
            {
                enemy = Instantiate(r2);
            }
            else if (i > 10 && i < 15)
            {
                enemy = Instantiate(r3);
            }
            else if (i > 14 && i < 21)
            {
                enemy = Instantiate(r4);
            }

            enemy.SetActive(false); // Desactivar la bala para que no sea visible ni interaccione
            rayos.Add(enemy);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("mandarEnemy", 2, 2);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void mandarEnemy()
    {

        if (rayos.Count > 0)
        {

            float randY = Random.Range(yMin, yMax);
            posicionPartida.y = randY;

            rayos.RemoveAt(0);
            rayos[0].transform.position = posicionPartida;
            rayos[0].SetActive(true);

        }


    }

    public void devolverEnemy(GameObject enemy)
    {
        enemy.SetActive(false);
        rayos.Add(enemy);

    }
}
