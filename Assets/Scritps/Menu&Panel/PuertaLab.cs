using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaLab : MonoBehaviour
{

    public GameObject btnPuerta;
    public GameObject puerta;

    //private bool pickUpAllowed;


    // Start is called before the first frame update
    void Start()
    {
        btnPuerta.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.name.Equals("IdCard"))
        //{
        //    //pickUp.SetActive(true);
        //    pickUpAllowed = true;

        //}

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("PuertaLab") && TarjetaId.IdCard == 1)
        {
            btnPuerta.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if (collision.gameObject.name.Equals("IdCard"))
        //{
        //    //pickUp.SetActive(false);
        //    pickUpAllowed = false;
        //}
        if (collision.gameObject.name.Equals("PuertaLab") && TarjetaId.IdCard == 1)
        {
            btnPuerta.SetActive(false);
        }
    }

    // Botón
    public void AbrirPuerta()
    {
        Destroy(puerta);

    }



}
