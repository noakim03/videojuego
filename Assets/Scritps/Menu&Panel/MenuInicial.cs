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
    public GameObject jugador;
    public GameObject canva;


    private TransferMap mapa;
    private int nivel;
    private void Start()
    {
        Time.timeScale = 1; // Para que no este congelado el personaje

        PlayerPrefs.SetInt("Piezas", 0);
        PlayerPrefs.SetInt("Vidas", 3);
    }



    const bool V = true;

    public void Jugar()
    {
        //PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Valtroix");
        Cursor.visible = false;

        PlayerPrefs.SetInt("Puntaje", 0);
        PlayerPrefs.SetInt("Piezas", 0);
        PlayerPrefs.SetInt("Vidas", 3);

        //if (jugador = GameObject.Find("Player"))
        //{
        //    jugador.GetComponent<SpriteRenderer>().enabled = V;
        //    Time.timeScale = 1;
        //}
        //else
        //{
        //    SceneManager.LoadScene("Valtroix");
        //}

    }

    public void Salir()
    {

        Application.Quit();
        Debug.Log("Salir...");
    }
}
