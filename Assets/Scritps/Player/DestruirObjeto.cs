using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Autor: Noh ah Kim Kwon
 * Para destruir cajas (Box)
 */
public class DestruirObjeto : MonoBehaviour
{
    private Animator anim;

    [SerializeField] private int vida;

    void Start()
    {
        anim = GetComponent<Animator>();

    }

    public void TomarDa�o(int da�o)
    {
        vida -= da�o;

        if (vida <= 0)
        {
            anim.Play("CajaDestruida");
            Destroy(gameObject, 0.5f);
        }
    }
}
