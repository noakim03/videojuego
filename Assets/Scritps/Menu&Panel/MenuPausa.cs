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
    public GameObject controles;
    public GameObject arma;
    // Estado del juego
    private bool estaPausado = false;

    public GameObject jugador;

    // Panel GameOver
    public GameObject gameOver;

    public static MenuPausa instance;

    private void Awake()
    {
        instance = this;    // Apuntador al objeto
    }

    public void Pausa()
    {
        Cursor.visible = true;
        controles.SetActive(false);

        panelPausa.SetActive(true);
        GameObject originalGameObject = GameObject.Find("Player");
        GameObject arma = originalGameObject.transform.GetChild(0).gameObject;
        arma.SetActive(false);
        Time.timeScale = 0;
        estaPausado = true;
    }

    // Botón Continuar
    public void ContinuarJuego()   // Click al botón Continuar de la pausa
    {
        Cursor.visible = false;
        panelPausa.SetActive(false);
        GameObject originalGameObject = GameObject.Find("Player");
        GameObject arma = originalGameObject.transform.GetChild(0).gameObject;
        arma.SetActive(true);
        Time.timeScale = 1;
        estaPausado = false;
    }

    public void Controles()   // Click al botón Continuar de la pausa
    {
        //Cursor.visible = false;
        panelPausa.SetActive(false);
        controles.SetActive(true);
        //GameObject originalGameObject = GameObject.Find("Player");
        //GameObject arma = originalGameObject.transform.GetChild(0).gameObject;
        
        //arma.SetActive(false);
        //Time.timeScale = 1;
        //estaPausado = true;
    }

    // Botón Salir
    public void MenuInicial()
    {
        //Destroy(gameObject);

        //  Hace un reset del score a 0
        ControladorPuntos.instance.score = 0;
        Redes.instance.puntuacion();
        Redes.instance.horaFinal();
        SceneManager.LoadScene("Menu");
        

        //jugador.SetActive(false);

        //guarda juego cuando se salga

    }

    void Update()  // Revisar mal comportamiento y cambiar a Update
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (estaPausado)
            {
                ContinuarJuego();
            }
            else
            {
                Pausa();
            }
        }
    }
    
    public void GameOver()
    {
        gameOver.SetActive(true);
    }

    public void Restart()
    {
        //  Hace un reset del score a 0
        //SceneManager.LoadScene("Valtroix");

        //PlayerPrefs.SetInt("Piezas", 0);

        //Time.timeScale = 1;
        //Cursor.visible = false;
        Redes.instance.puntuacion();


        ControladorPuntos.instance.score = 0;
        SceneManager.LoadScene("Valtroix");
        Cursor.visible = false;

        //PlayerPrefs.SetInt("Puntaje", 0);
        PlayerPrefs.SetInt("Piezas", 0);
        PlayerPrefs.SetInt("Vidas", 3);

        //jugadorEnem();

    }

    private static void jugadorEnem()
    {
        GameObject originalGameObject = GameObject.Find("Player");
        GameObject arma = originalGameObject.transform.GetChild(0).gameObject;
        arma.SetActive(true);

        GameObject enemigos = GameObject.Find("Enemigos");
        enemigos.SetActive(true);
    }
}