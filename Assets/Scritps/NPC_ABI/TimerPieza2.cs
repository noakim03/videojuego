using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerPieza2 : MonoBehaviour

/**
 * Autor: Abigail Chávez Rubio
 * Timer que aprece en el quiz
 */
{
    [SerializeField] private float tiempoMaximo;
    [SerializeField] private Slider slider;

    private float tiempoActual;
    private bool tiempoActivado = false;
    public GameObject panelTimeOut;

    public static TimerPieza2 instance;

    // Start is called before the first frame update
    // Update is called once per frame

    void Update()
    {
        if (tiempoActivado)
        {
            CambiarContador();
        }
    }

    private void Awake()
    {
        instance = this;    // Apuntador al objeto

    }

    public void CambiarContador()
    {
        tiempoActual -= Time.deltaTime;

        if (tiempoActual >= 0)
        {
            slider.value = tiempoActual;
        }
        //textoTimer.text = "" + tiempoActual.ToString("f0");

        if (tiempoActual <= 0)
        {
            panelTimeOut.SetActive(true);
            cambiarTemporizador(false);

        }
    }

    public void cambiarTemporizador(bool estado)
    {
        tiempoActivado = estado;
    }

    public void ActivarTemporizador()
    {
        tiempoActual = tiempoMaximo;
        slider.maxValue = tiempoMaximo;
        cambiarTemporizador(true);
    }

    public void DesactivarTemporizador()
    {
        cambiarTemporizador(false);
    }
}

