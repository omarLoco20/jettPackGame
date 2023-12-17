using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class passScene : MonoBehaviour
{
    //public string menu="menu";
    //private string nameMenu;

    private void Awake()
    {
        //nameMenu = SceneManager.GetActiveScene().name;
    }
    // Start is called before the first frame update
    void Start()
    {
        //string nombreDeEscenaActual = SceneManager.GetActiveScene().name;
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("splash"))
        {
            Invoke("ChangeScene", 4f);
        }
        else
        {
            this.gameObject.SetActive(false);
        }

    }

    void ChangeScene()
    {
        SceneManager.LoadScene("menu");

    }
}
