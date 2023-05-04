using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Botones : MonoBehaviour
{
    /**
     * Autor: Abigail Chávez Rubio
     * Botones para aceptar o no el quiz (solo se hace una vez)
     */

    public GameObject Quiz;
    public GameObject tecla;
    public GameObject dialogBox;
    public GameObject botones;
    public GameObject npc;


    public void Yes()
    {
        botones.SetActive(false);
        Quiz.SetActive(true);
        Timer.instance.ActivarTemporizador();
        GameObject originalGameObject = GameObject.Find("Player");
        GameObject arma = originalGameObject.transform.GetChild(0).gameObject;
        arma.SetActive(false);
        Cursor.visible = true;
        npc.SetActive(false);
    }

    public void No()
    {
        Time.timeScale = 1;
        GameObject originalGameObject = GameObject.Find("Player");
        GameObject arma = originalGameObject.transform.GetChild(0).gameObject;
        arma.SetActive(true);
        Cursor.visible = false;
        botones.SetActive(false);
        npc.SetActive(true);

    }

}
