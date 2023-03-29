using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
  * Autor: Noh ah Kim Kwon
  * Define la respuesta a los eventos de la GUI
 */

public class MenuInicial : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1; // Para que no este congelado el personaje
    }
    public void Jugar()
    {
        SceneManager.LoadScene("Valtroix");
    }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("Salir...");
    }
}
