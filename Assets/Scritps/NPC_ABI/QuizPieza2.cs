using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizPieza2 : MonoBehaviour
{
    /**
     * Autor: Abigail Chávez Rubio
     * Quiz manager, preguntas y respuestas
     */
    public GameObject panelCorrecto;
    public GameObject panelInorrecto;
    public GameObject Quiz2;
    public GameObject botones;
    public GameObject tecla;

    public GameObject npc2;
    public GameObject panelTimeOut;
    [SerializeField] private int cantidadPuntos;

    public void correcto()
    {
        panelCorrecto.SetActive(true);
        TimerPieza2.instance.cambiarTemporizador(false);
        ControladorPuntos.instance.SumarPuntos(cantidadPuntos);
        SaludPersonaje.instance.piezas++;
        HUD.instance.ActualizarPiezas();

    }

    public void incorrecto()
    {
        panelInorrecto.SetActive(true);
        TimerPieza2.instance.cambiarTemporizador(false);
    }

    public void continuarCor()
    {
        panelCorrecto.SetActive(false);
        Quiz2.SetActive(false);
        //GameObject npc = GameObject.Find("NPC2");
        //npc.SetActive(false);

        botones.SetActive(false);

        GameObject originalGameObject = GameObject.Find("Player");
        GameObject arma = originalGameObject.transform.GetChild(0).gameObject;
        arma.SetActive(true);
        Cursor.visible = false;


    }

    public void continuarIncor()
    {

        panelInorrecto.SetActive(false);
        Quiz2.SetActive(false);
        botones.SetActive(false);

        //GameObject npc2 = GameObject.Find("NPC2");
        npc2.SetActive(true);

        GameObject originalGameObject = GameObject.Find("Player");
        GameObject arma = originalGameObject.transform.GetChild(0).gameObject;
        arma.SetActive(true);
        Cursor.visible = false;


    }

    public void continuarTime()
    {
        //GameObject npc2 = GameObject.Find("NPC2");
        npc2.SetActive(true);

        panelTimeOut.SetActive(false);
        Quiz2.SetActive(false);
        botones.SetActive(false);

        GameObject originalGameObject = GameObject.Find("Player");
        GameObject arma = originalGameObject.transform.GetChild(0).gameObject;
        arma.SetActive(true);
        Cursor.visible = false;

        //dialogBox.SetActive(false);

    }
}
