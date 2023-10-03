using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class botonesCode : MonoBehaviour
{
    public GameObject panelOpciones;

   public void GoPLay()
    {
        SceneManager.LoadScene("SampleScene");
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
}
