using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class passScene : MonoBehaviour
{
    public string menu="menu";
    
    // Start is called before the first frame update
    void Start()
    {
        string nombreDeEscenaActual = SceneManager.GetActiveScene().name;
        if (nombreDeEscenaActual == "splash")
        {
            Invoke("irMenu", 4f);
        }
        if (nombreDeEscenaActual != "splash")
        {
            this.gameObject.SetActive(false);
        }
    }

   void irMenu()
    {
        SceneManager.LoadScene(menu);
       
    }
}
