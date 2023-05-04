using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizPieza : MonoBehaviour
{
    /**
     * Autor: Abigail Chávez Rubio
     * Quiz manager, preguntas y respuestas
     */
    public GameObject panelCorrecto;
    public GameObject panelInorrecto;
    public GameObject Quiz;
    public GameObject botones;
    public GameObject tecla;

    public GameObject npc2;
    [SerializeField] private int cantidadPuntos;

    
    public GameObject panelTimeOut;

    public void correcto()
    {
        panelCorrecto.SetActive(true);
        TimerPieza.instance.cambiarTemporizador(false);
        ControladorPuntos.instance.SumarPuntos(cantidadPuntos);
        SaludPersonaje.instance.piezas++;
        HUD.instance.ActualizarPiezas();

    }

    public void incorrecto()
    {
        panelInorrecto.SetActive(true);
        TimerPieza.instance.cambiarTemporizador(false);
    }

    public void continuarCor()
    {
        panelCorrecto.SetActive(false);
        Quiz.SetActive(false);
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
        Quiz.SetActive(false);
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
        Quiz.SetActive(false);
        botones.SetActive(false);


        GameObject originalGameObject = GameObject.Find("Player");
        GameObject arma = originalGameObject.transform.GetChild(0).gameObject;
        arma.SetActive(true);
        Cursor.visible = false;

        //dialogBox.SetActive(false);

    }
}
