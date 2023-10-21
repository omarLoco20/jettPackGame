using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class codeDj : MonoBehaviour
{
    AudioSource audioS;
    public scriptableMusic musicas;
   
    // Start is called before the first frame update
    void Start()
    {

        /* audioS = GetComponent<AudioSource>();
         audioS.PlayOneShot(musicas.musicBackground);*/
        DontDestroyOnLoad(this.gameObject);
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
