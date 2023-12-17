using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{
    [SerializeField]
    private GameObject pipePrefab;
    [SerializeField]
    private int poolSize = 15;

    private List<GameObject> pooledPipes;

    private void Awake()
    {
        pooledPipes = new List<GameObject>();

        for(int i = 0; i < poolSize; i++)
        {
            GameObject pipe = Instantiate(pipePrefab);
            pipe.SetActive(false);
            pooledPipes.Add(pipe);
        }
    }

    public GameObject GetPoolPipe()
    {
        foreach(GameObject pipe in pooledPipes)
        {
            if (!pipe.activeInHierarchy)
            {
                return pipe;
            }
        }
        return null;
    }
}
