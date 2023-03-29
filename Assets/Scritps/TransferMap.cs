using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Autor: Noh Ah Kim Kwon
 * Transferir al personaje a otro mapa
 * 
 * Referencia: https://www.youtube.com/watch?v=5Pnj2lDtd70&list=PLUZ5gNInsv_NW8RQx8__0DxiuPZn3VDzP&index=8
 */

public class TransferMap : MonoBehaviour
{
    public string transferMapName;  // Nombre del mapa al que se vaa mover

    
    void Start()
    {
        
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            SceneManager.LoadScene(transferMapName);
        }
    }
}
