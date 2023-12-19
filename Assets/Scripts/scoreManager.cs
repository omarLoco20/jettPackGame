using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreManager : MonoBehaviour
{
    public scriptableScore scoreManage;
    public List<TextMeshProUGUI> listaTextos;
    // Start is called before the first frame update
    void Start()
    {
        List<int> sortedScores = scoreManage.GetHighScores();

        // Asegúrate de que haya al menos 10 puntajes para mostrar.
        for (int i = 0; i < listaTextos.Count && i < sortedScores.Count; i++)
        {
            // Asigna el puntaje al TextMeshPro correspondiente.
            listaTextos[i].text = (i + 1) + ") " + sortedScores[i].ToString();
        }

    }

   
}
