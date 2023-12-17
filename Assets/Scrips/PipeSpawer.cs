
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawer : MonoBehaviour
{
    [SerializeField]
    private Pooler pooler;
    [SerializeField]
    private float spawnInterval = 1.0f;
    [SerializeField]
    private float minY = -1.0f;
    [SerializeField]
    private float maxY = 4.0f;

    float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > spawnInterval)
        {
            SpawnPipe();
            timer = 0;
        }
    }

    void SpawnPipe()
    {
        float randomY = Random.Range(minY,maxY);
        GameObject pipe = pooler.GetPoolPipe();

        if(pipe != null )
        {
            pipe.transform.position = new Vector3(transform.position.x, randomY,0);
            pipe.SetActive(true);
        }
    }
}
