using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "scriptableObject", menuName = "scriptables/scriptableScore")]

public class scriptableScore : ScriptableObject
{
  public List<int> highScores;

    private int maxHighScores = 6; // Define la cantidad máxima de puntajes a mantener.
   // public GameObject confeti;

    public List<int> GetHighScores()
    {
        // Ordena la lista de puntajes de mayor a menor.
        highScores.Sort((a, b) => b.CompareTo(a));

        // Asegura que solo haya 10 puntajes en la lista.
        if (highScores.Count > maxHighScores)
        {
            highScores.RemoveRange(maxHighScores, highScores.Count - maxHighScores);
        }

        return highScores;
    }

    public void AddHighScore(int newScore)
    {
        highScores.Add(newScore);
    }

    public bool compareBest(int newScore)
    {
       List<int> newList= GetHighScores();

        if (newList[0] < newScore)
        {
            return true;
        }
        else
        {
            return false;
        }
            
    }

}
