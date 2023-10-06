using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class botonesCode : MonoBehaviour
{
    public GameObject panelOpciones;
    public ScriptableSelector p1;
    public ScriptableSelector p2;
    public ScriptableSelector p3;
    public ScriptableSelector pActual;


    public void menuIr()
    {
        SceneManager.LoadScene("menu");
    }

    public void GoPLay()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void selectorCharacter()
    {
        SceneManager.LoadScene("seleccionPlayer");

    }

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
