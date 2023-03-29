using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
  * Autor: Noh ah Kim Kwon
  * Movimiento del personaje
 */

public class MoverPersonaje : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animador;
    
    public float moveSpeed = 5f;
    Vector2 mov;    // movimiento


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animador = GetComponent<Animator>();
    }

    void Update()
    {
        mov.x = Input.GetAxisRaw("Horizontal");
        mov.y = Input.GetAxisRaw("Vertical");

        animador.SetFloat("Horizontal", mov.x);
        animador.SetFloat("Vertical", mov.y);
        animador.SetFloat("Velocidad", mov.sqrMagnitude);

    }

    void FixedUpdate()
    {
        // Movimiento

        rb.MovePosition(rb.position + mov.normalized * moveSpeed * Time.fixedDeltaTime);
    }


}
