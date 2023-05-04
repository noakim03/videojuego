using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] private int daño;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private AudioSource audioSource;
    public AudioClip disparo;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameObject.SetActive(true); //Visible

        spriteRenderer = GetComponent<SpriteRenderer>();

        audioSource = GetComponent<AudioSource>();

    }

    void Update()
    {
        if (!spriteRenderer.isVisible)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.transform.Rotate(0, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo"))
        {
            audioSource.PlayOneShot(disparo);
            collision.GetComponent<Enemigo>().TomarDaño(daño);
            Destroy(gameObject, 0.06f);
        }
        else if (collision.CompareTag("Caja"))
        {
            audioSource.PlayOneShot(disparo);
            collision.GetComponent<DestruirObjeto>().TomarDaño(daño);
            Destroy(gameObject, 0.06f);
        }
    }
}
