using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class codeMisil : MonoBehaviour
{
    public int speed;
    //public spawnerElementos sE;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "detector")
        {
            spawnerMisil sM = GameObject.FindGameObjectWithTag("spawnerMisil").GetComponent<spawnerMisil>();
            sM.devolverEnemy(this.gameObject);
        }
    }
}
