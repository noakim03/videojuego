using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/**
 * Autor: Noh Ah Kim Kwon
 * Generar un cuadro de diálogo de señal al tocar el señal
 */

public class Boton : MonoBehaviour
{
    public GameObject dialogBox;
    public bool dialogActive;
    public bool playerInRange;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            dialogBox.SetActive(true);

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            dialogBox.SetActive(false);
        }
    }
}
