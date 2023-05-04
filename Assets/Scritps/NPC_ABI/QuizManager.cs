using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
    /**
     * Autor: Abigail Chávez Rubio
     * Quiz manager, preguntas y respuestas para puntos extras (solo se hace una vez)
     */
    public GameObject panelCorrecto;
    public GameObject panelInorrecto;
    public GameObject Quiz;
    public GameObject botones;
    public GameObject tecla;
    [SerializeField] private int cantidadPuntos;

    public GameObject panelTimeOut;

    public void correcto()
    {
        panelCorrecto.SetActive(true);
        Timer.instance.cambiarTemporizador(false);
        ControladorPuntos.instance.SumarPuntos(cantidadPuntos);

    }

    public void incorrecto()
    {
        panelInorrecto.SetActive(true);
        Timer.instance.cambiarTemporizador(false);
    }

    public void continuarCor()
    {
        panelCorrecto.SetActive(false);
        Quiz.SetActive(false);
        //GameObject npc = GameObject.Find("NPC1");
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
        //GameObject npc = GameObject.Find("NPC1");
        //npc.SetActive(false);

        botones.SetActive(false);

        GameObject originalGameObject = GameObject.Find("Player");
        GameObject arma = originalGameObject.transform.GetChild(0).gameObject;
        arma.SetActive(true);
        Cursor.visible = false;

    }

    public void continuarTime()
    {
        panelTimeOut.SetActive(false);
        Quiz.SetActive(false);
        //GameObject npc = GameObject.Find("NPC1");
        //npc.SetActive(false);
        
        botones.SetActive(false);

        GameObject originalGameObject = GameObject.Find("Player");
        GameObject arma = originalGameObject.transform.GetChild(0).gameObject;
        arma.SetActive(true);
        Cursor.visible = false;
        
    }
}
