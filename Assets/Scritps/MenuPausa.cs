using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Autor: Noh Ah Kim Kwon
 * Maneja la pausa de la escena mapa
 */

public class MenuPausa : MonoBehaviour
{
    // Panel MenuPausa

    // Referencia al panel que muestra el menú de Pausa
    public GameObject panelPausa;
    // Estado del juego
    private bool estaPausado = false;

    public void ContinuarJuego()   // Click al botón Continuar de la pausa
    {
        Pausa();
    }

    void Pausa()
    {
        estaPausado = !estaPausado;
        panelPausa.SetActive(estaPausado);
        Time.timeScale = estaPausado ? 0 : 1;
    }

    public void MenuInicial()
    {
        SceneManager.LoadScene("Menu");
    }

    private void Update()  // Revisar mal comportamiento y cambiar a Update
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pausa();
        }
    }
}