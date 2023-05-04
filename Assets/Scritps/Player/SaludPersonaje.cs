using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Autor: Noh Ah Kim Kwon
 * Mantiene información de la salud del personaje (número de vidas)
 */


public class SaludPersonaje : MonoBehaviour
{
    public int vidas = 3;       // Vidas iniciales
    public int piezas = 0;
    private bool estaMuerto;
    public GameObject puerta;
    public GameObject puertaLab;

    public static SaludPersonaje instance;  // 

    private void Awake()
    {
        instance = this;    // Apuntador al objeto
    }

    private void Start()
    {
        piezas = PlayerPrefs.GetInt("Piezas", 0);
        vidas = PlayerPrefs.GetInt("Vidas", 0);
        //PlayerPrefs.DeleteAll();
    }

    void Update()
    {
        if (vidas == 0 && !estaMuerto)
        {
            estaMuerto = true;
            Cursor.visible = true;
            Time.timeScale = 0;
            //Destroy(collision.gameObject, 0.3f);
            MenuPausa.instance.GameOver();
            GameObject originalGameObject = GameObject.Find("Player");
            GameObject arma = originalGameObject.transform.GetChild(0).gameObject;
            arma.SetActive(false);

            GameObject enemigos = GameObject.Find("Enemigos");
            enemigos.SetActive(false);

            // Guardar el puntaje máximo
            //PlayerPrefs.SetInt("numeroMonedas", SaludPersonaje.instance.piezas);
            //PlayerPrefs.Save(); // Guarda en el sistema de archivos
        }
        // Si llega a recolectar las piezas con NPCs
        if (piezas == 5)
        {
            // Coleccionar 3 piezas para remover la roca y pasar a TechCity
            Destroy(puerta);
        }
        else if (piezas == 10)
        {
            // Coleccionar 10 piezas para abrir la puerta de la nave en TechCity
            Destroy(puertaLab);
        }
    }

    //public int GetHealth()
    //{
    //    return vidas;
    //}
    //public void SetHealth(int playerHealth)
    //{
    //    vidas = playerHealth;

    //}
}
