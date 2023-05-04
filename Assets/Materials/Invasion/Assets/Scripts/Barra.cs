using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barra : MonoBehaviour
{

    public GameObject explosionPrefab;
    private Vector2 screenBounds;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            SaludPersonaje.instance.vidas--;
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            HUD.instance.ActualizarVidas();
            //Destroy(collision.gameObject);
            Destroy(gameObject);
            Destroy(explosion, 2f);
          
          
        }
    }

 
}
