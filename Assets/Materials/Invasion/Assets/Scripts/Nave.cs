using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{
    //Variables de instancia
    [SerializeField]
    private float velocidadX;

    private Rigidbody2D rb;
    private Vector2 velocidad;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velocidad = new Vector2();
    }

    // Update is called once per frame
    void Update()
    {
        float movHorizontal = Input.GetAxis("Horizontal");
        velocidad.x = movHorizontal * velocidadX;
        velocidad.y = rb.velocity.y;
        rb.velocity = velocidad;
    }
}
