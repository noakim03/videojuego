using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BotonesPieza2 : MonoBehaviour
{
    /**
     * Autor: Abigail Chávez Rubio
     * Botones para aceptar o no el quiz (se hace varias veces)
     */

    public GameObject Quiz;
    public GameObject tecla;
    public GameObject botones;
    public GameObject npc2;

    public void Yes()
    {
        Quiz.SetActive(true);
        TimerPieza2.instance.ActivarTemporizador();
        GameObject originalGameObject = GameObject.Find("Player");
        GameObject arma = originalGameObject.transform.GetChild(0).gameObject;
        arma.SetActive(false);
        Cursor.visible = true;
    }

    public void No()
    {
        Time.timeScale = 1;
        GameObject originalGameObject = GameObject.Find("Player");
        GameObject arma = originalGameObject.transform.GetChild(0).gameObject;
        arma.SetActive(true);
        Cursor.visible = false;
        botones.SetActive(false);
        npc2.SetActive(true);
        //Cursor.visible = false;
    }

}
