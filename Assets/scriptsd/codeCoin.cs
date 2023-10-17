using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class codeCoin : MonoBehaviour
{

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.gameObject.SetActive(false);
            Invoke("activarAgain", 2f);
        }
       
    }
    public void activarAgain()
    {
        this.gameObject.SetActive(true);
    }
}
