using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/**
 * Autor: Noh Ah Kim Kwon
 * Generar un cuadro de diálogo de señal al tocar el señal
 */

public class DialogoObjeto : MonoBehaviour
{
    public GameObject dialogBox;
    public TMP_Text dialogText;
    //public string dialog;
    public bool dialogActive;
    public bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            dialogBox.SetActive(true);
            //dialogText.text = dialog;

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
