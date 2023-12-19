using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class codeBilletera : MonoBehaviour
{
    public ScriptableSelector sp;
    public TextMeshProUGUI textCoins;
    // Start is called before the first frame update
    void Start()
    {
        textCoins.text = "" + sp.coins;
    }

    public void actualizarMonedero()
    {
        textCoins.text = "" + sp.coins;
    }

   
}
