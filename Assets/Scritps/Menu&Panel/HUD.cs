using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/**
 * Autor: Noh Ah Kim Kwon
 * Administrar los componentes del HUD (vidas, piezas)
 */
public class HUD : MonoBehaviour
{
    // Referencias a los corazones (Tipo:Image)
    public Image imagen1;
    public Image imagen2;
    public Image imagen3;
    public Image imagen4;
    public Image imagen5;
    public Image Pieza;
    public Image carta;

    // Referencia al contador
    public TMP_Text contadorPiezas;
    


    public static HUD instance;

    // Para cargar el número de monedas almacenado previamente
    private void Start()
    {
        //carta.enabled = false;

        int piezas = PlayerPrefs.GetInt("numPiezas", SaludPersonaje.instance.piezas);
        contadorPiezas.text = piezas.ToString(); // Pantalla
        SaludPersonaje.instance.piezas = piezas;
        //ActualizarMonedas();

        //int vidas = PlayerPrefs.GetInt("Vidas", SaludPersonaje.instance.vidas);
        //SaludPersonaje.instance.vidas = vidas;
        ActualizarVidas();

    }

    private void Awake()
    {
        instance = this;
        //if (HUD.instance == null)
        //{
        //    HUD.instance = this;
        //    DontDestroyOnLoad(this.gameObject);
        //}
        //else
        //{
        //    Destroy(this.gameObject);
        //}
    }

    // Actualiza el contador de monedas
    internal void ActualizarPiezas()
    {
        int piezas = SaludPersonaje.instance.piezas;
        contadorPiezas.text = piezas.ToString();
        PlayerPrefs.SetInt("Piezas", piezas);
        print("guarda pieza");
        PlayerPrefs.Save();

    }


    // Actualizar el HUD
    internal void ActualizarVidas() // Pueden acceder a actualizar todas las clases del proyecto 
    {   
        int vidas = SaludPersonaje.instance.vidas;

        if (vidas == 0)
        {
            // Apagar la imagen 1
            //imagen1.enabled = false;
            Destroy(imagen1);

        } else if (vidas == 1)
        {
            // Apagar la imagen 2
            //imagen2.enabled = false;
            Destroy(imagen2);

        }
        else if (vidas == 2)
        {
            // Apagar la imagen 3
            imagen3.enabled = false;
        }
        PlayerPrefs.SetInt("Vidas", vidas);
        PlayerPrefs.Save();

        print("ouch");
    }


    internal void IdCard()
    {
        int idcard = TarjetaId.IdCard;
        if (idcard == 1)
        {
            carta.enabled = true;
        }
    }

}
