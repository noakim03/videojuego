using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogoPieza2 : MonoBehaviour
{
    /**
     * Autor: Abigail Chávez Rubio
     * Dialogo del NPC para poder obetener una pieza, la tarea se puede hacer varias veces
     */

    private bool isPlayerInRange;
    private bool empezoDialogo;
    private int lineIndex;

    public GameObject tecla;
    public GameObject dialogBox;
    public TMP_Text dialogText;
    public GameObject botones;

    [SerializeField, TextArea(4, 6)] private string[] dialogo;


    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!empezoDialogo)
            {
                iniciarDialogo();
            }
            else if (dialogText.text == dialogo[lineIndex])
            {
                sigLinea();
            }
            else //para que vaya rapido
            {
                StopAllCoroutines();
                dialogText.text = dialogo[lineIndex];
            }

        }
    }

    private void iniciarDialogo()
    {
        empezoDialogo = true;
        dialogBox.SetActive(true);
        tecla.SetActive(false);
        lineIndex = 0;
        Time.timeScale = 0f; //para que no se mueva el jugador
        StartCoroutine(showLine());
    }

    private void sigLinea()
    {
        lineIndex++;
        if (lineIndex < dialogo.Length)
        {
            StartCoroutine(showLine());
        }
        else //cuando se termina el dialogo
        {
            empezoDialogo = false;
            dialogBox.SetActive(false);
            GameObject npc = GameObject.Find("NPC3");
            npc.SetActive(false);
            botones.SetActive(true);
            Time.timeScale = 1f;


            GameObject originalGameObject = GameObject.Find("Player");
            GameObject arma = originalGameObject.transform.GetChild(0).gameObject;
            arma.SetActive(false);
            Cursor.visible = true;



        }
    }

    private IEnumerator showLine()
    {
        dialogText.text = string.Empty; //no tiene nada en el inicio

        foreach (char ch in dialogo[lineIndex])
        {
            dialogText.text += ch; //concatenar caracter por caracter
            yield return new WaitForSecondsRealtime(0.05f);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            isPlayerInRange = true;
            tecla.SetActive(true);
            GameObject originalGameObject = GameObject.Find("Player");
            GameObject arma = originalGameObject.transform.GetChild(0).gameObject;
            arma.SetActive(false);
        }

    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            isPlayerInRange = false;
            tecla.SetActive(false);
            botones.SetActive(false);
            GameObject originalGameObject = GameObject.Find("Player");
            GameObject arma = originalGameObject.transform.GetChild(0).gameObject;
            arma.SetActive(true);
        }
    }


}

