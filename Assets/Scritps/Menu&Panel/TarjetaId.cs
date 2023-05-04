using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//Referencia: https://www.youtube.com/watch?v=yFKg8qVclBk

public class TarjetaId : MonoBehaviour
{
    public static int IdCard;

    private void Start()
    {
        IdCard = 0;
    }

    public void PickUp()
    {
        Destroy(gameObject);
    }


    private bool pickUpAllowed;


    // Update is called once per frame
    void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(gameObject);
            TarjetaId.IdCard++;  // Conteo
            //if (SaludPersonaje.instance.idCard == 1)
            //{
            //    // Coleccionar 3 piezas para remover la roca y pasar a TechCity
            //    Destroy(puerta);
            //}
            HUD.instance.IdCard();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            //pickUp.SetActive(true);
            pickUpAllowed = true;

        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            //pickUp.SetActive(false);
            pickUpAllowed = false;
        }

    }

}
