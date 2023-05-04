using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string transferMapName;  // Nombre del mapa al que se va mover
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            Redes.instance.estado();

            //Cursor.visible = true;
            SceneManager.LoadScene(transferMapName);



            //dialogText.text = dialog;

        }
    }

}
