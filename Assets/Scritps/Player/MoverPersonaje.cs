using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



/**
  * Autor: Noh ah Kim Kwon
  * Movimiento del personaje
 */

public class MoverPersonaje : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animador;

    public string currentMap;

    public float moveSpeed = 5f;
    private Vector3 mov;    // movimiento

    public GameObject pickUp;


    static public MoverPersonaje instance;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animador = GetComponent<Animator>();

        //if (instance == null)
        //{
        //    instance = this;
        //    DontDestroyOnLoad(gameObject);
        //    rb = GetComponent<Rigidbody2D>();
        //    animador = GetComponent<Animator>();

        //    //int piezas = playerprefs.getint("numpiezas", saludpersonaje.instance.piezas);
        //    //saludpersonaje.instance.piezas = piezas;
        //    //hud.instance.actualizarmonedas();
        //}
        //else
        //{
        //    Destroy(this.gameObject);
        //}


    }

    void Update()
    {
        mov = Vector3.zero;
        mov.x = Input.GetAxisRaw("Horizontal");
        mov.y = Input.GetAxisRaw("Vertical");


            UpdateAnimationAndMove();
    }    

    void UpdateAnimationAndMove()
    {
        if (mov != Vector3.zero)
        {
            animador.SetFloat("Horizontal", mov.x);
            animador.SetFloat("Vertical", mov.y);
            animador.SetFloat("Velocidad", mov.sqrMagnitude);
            animador.SetBool("Moviendo", true);
        }
        else
        {
            animador.SetBool("Moviendo", false);
        }
    }


    void FixedUpdate()
    {
        // Movimiento
        rb.MovePosition(transform.position + mov.normalized * moveSpeed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("IdCard"))
        {
            pickUp.SetActive(true);
            
        }
        else if (collision.gameObject.name.Equals("task"))
        {
            pickUp.SetActive(true);
        }
        else if (collision.gameObject.name.Equals("NaveDestruida"))
        {
            pickUp.SetActive(true);
        }
        else if (collision.gameObject.name.Equals("Robot"))
        {
            pickUp.SetActive(true);
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("IdCard"))
        {
            pickUp.SetActive(false);          
        }
        else if (collision.gameObject.name.Equals("task"))
        {
            pickUp.SetActive(false);
        }
        else if (collision.gameObject.name.Equals("NaveDestruida"))
        {
            pickUp.SetActive(false);
        }
        else if (collision.gameObject.name.Equals("Robot"))
        {
            pickUp.SetActive(false);
        }

    }


    //public Vector2 GetPosition()
    //{
    //    return transform.position;
    //}
    //public void SetPosition(Vector2 pos)
    //{
    //    transform.position = pos;
    //}
}
