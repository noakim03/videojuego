using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Autor: Noh ah Kim Kwon
 * Detecta colisiones (personaje)
 */

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float vida;
    [SerializeField] private float Maxvida = 100;
    [SerializeField] private int cantidadPuntos;
    [SerializeField] private AudioClip sonido;

    public HealthBar HP;


    void Start()
    {
        vida = Maxvida;
        HP.SetHealth(vida, Maxvida);
    }

    public void TomarDaño(int daño)
    {
        vida -= daño;
        HP.SetHealth(vida, Maxvida);

        if (vida <= 0)
        {
            ControladorPuntos.instance.SumarPuntos(cantidadPuntos);
            Destroy(gameObject);
        }
    }
    //public GameObject proyectil;    // Original (prefab)
    //private void Start()
    //{
    //    StartCoroutine(GenerarDisparo());
    //}

    //IEnumerator GenerarDisparo()
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(1.5f);  // Timer de 1.5seg
    //        GameObject nuevoProyectil = Instantiate(proyectil);
    //        nuevoProyectil.transform.position = gameObject.transform.position;
    //        nuevoProyectil.SetActive(true);
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ¿Colisiona con el personaje?
        if (collision.gameObject.CompareTag("Player"))
        {
            ControladorSonido.instance.EjecutarSonido(sonido);
            // Quitar una vida 
            //SaludPersonaje.instance.vidas--;
            SaludPersonaje.instance.vidas--;

            //print(SaludPersonaje.instance.vidas);

            // Actualizar HUD
            HUD.instance.ActualizarVidas();

            
            

            //if (SaludPersonaje.instance.vidas == 0)
            //{
            //    Destroy(collision.gameObject, 0.3f);
            //    MenuPausa.instance.GameOver();
            //    // Guardar el puntaje máximo
            //    //PlayerPrefs.SetInt("numeroMonedas", SaludPersonaje.instance.piezas);
            //    //PlayerPrefs.Save(); // Guarda en el sistema de archivos
            //}
        }
    }
}
