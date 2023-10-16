using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class botonesCode : MonoBehaviour
{
    public GameObject panelOpciones;
    public ScriptableSelector p1;
    public ScriptableSelector p2;
    public ScriptableSelector p3;
    public ScriptableSelector pActual;
    public GameObject pausePanel;
    public GameObject listaScore;
    [SerializeField] string newScene;

    string menu= "menu";
    string game = "SampleScene";
    string seleccionar = "seleccionPlayer";

    private void Start()
    {
        SceneManager.LoadScene("splash", LoadSceneMode.Additive);
    }


    /* public int currentGold;
     [SerializeField] private int myGold;*/
    // public int defGold { private set; get; }

    //private Button myButton;
    /*
    private void Start()
    {
        myButton.onClick.AddListener(() => LoadScene("menu"));

    }*/

    public void abrirListaScore()
    {
        listaScore.SetActive(true);
    }
    public void cerrarListaScore()
    {
        listaScore.SetActive(false);

    }
    public void pauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;

    }

    public void closePause()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void menuIr()
    {
        SceneManager.LoadScene(menu);
    }

    

    public void GoPLay()
    {
        SceneManager.LoadScene(game);
       // LoadScene("SampleScene");
    }

    public void selectorCharacter()
    {
        SceneManager.LoadScene(seleccionar);

    }
    /*
    private void LoadScene(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }*/

    public void exit()
    {
        Application.Quit();
    }

    public void options()
    {
        panelOpciones.SetActive(true);
    }
    public void closeOptions()
    {
        panelOpciones.SetActive(false);

    }
    public void selectP1()
    {
        pActual.life = p1.life;
        pActual.force = p1.force;
        pActual.character = p1.character;
        // pActual.rotacion = p1.rotacion;
        pActual.cambiarFlip = p1.cambiarFlip;
    }
    public void selectP2()
    {
        pActual.life = p2.life;
        pActual.force = p2.force;
        pActual.character = p2.character;
        //  pActual.rotacion = p2.rotacion;
        pActual.cambiarFlip = p2.cambiarFlip;



    }

    public void selectP3()
    {
        pActual.life = p3.life;
        pActual.force = p3.force;
        pActual.character = p3.character;
        // pActual.rotacion = p3.rotacion;
        pActual.cambiarFlip = p3.cambiarFlip;



    }
}
