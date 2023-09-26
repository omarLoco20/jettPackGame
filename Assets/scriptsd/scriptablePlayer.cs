using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[CreateAssetMenu(fileName = "scriptableObject", menuName = "scriptables/playerScriptable")]
public class scriptablePlayer : ScriptableObject
{
    public int coins;
    public TextMeshProUGUI coinsText;
   public void contador()
    {

        coins++;
        coinsText.text = "Coins: " + coins;
        

    }
}
