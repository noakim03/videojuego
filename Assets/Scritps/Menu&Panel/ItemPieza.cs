using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Autor: Noh Ah Kim Kwon
 * Detecta la colisión de la pieza con el personaje
 */
public class ItemPieza : MonoBehaviour
{
    private AudioSource sonidoMoneda;
    public GameObject puerta;
    public GameObject puertaLab;


    [SerializeField] private int cantidadPuntos;
    private void Start()
    {
        // Hace visible la explosión
        //gameObject.transform.GetChild(0).gameObject.SetActive(false);
        //sonidoMoneda = GetComponent<AudioSource>();
    }
    // Detecta la colisión y desaparece la moneda, si la recolectó el personaje
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // El personaje colisionó con la moneda
            // Soinido
            //sonidoMoneda.Play();
            // Hace visible la explosión
            //gameObject.transform.GetChild(0).gameObject.SetActive(true);
            
            // Ocultar la pieza
            GetComponent<SpriteRenderer>().enabled = false;

            // Destruye la moneda después de 0.5 segundos
            ControladorPuntos.instance.SumarPuntos(cantidadPuntos);
            Destroy(gameObject, 0.5f);  //Destruye la pieza
            //Destroy(collision.gameObject, 0.3f);    //Destruye al personaje

            // Contar la pieza
            SaludPersonaje.instance.piezas++;  // Conteo

            // Si llega a recolectar las piezas collisionando
            if (SaludPersonaje.instance.piezas == 5)
            {
                // Coleccionar 3 piezas para remover la roca y pasar a TechCity
                Destroy(puerta);
            }
            else if (SaludPersonaje.instance.piezas == 10)
            {
                // Coleccionar 10 piezas para abrir la puerta de la nave en TechCity
                Destroy(puertaLab);
            }
            //Destroy(gameObject);

            // Actualizar el contador (Text)
            HUD.instance.ActualizarPiezas();

            
        }

    }

}
