using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveRoom : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            SaludPersonaje.instance.piezas = PlayerPrefs.GetInt("Piezas");
            SaludPersonaje.instance.vidas = PlayerPrefs.GetInt("Vidas");
            

            print("Game Saved");

        }
    }
}
