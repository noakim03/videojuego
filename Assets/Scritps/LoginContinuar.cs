using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class LoginContinuar : MonoBehaviour
{
    public GameObject panel;
    public TMP_InputField IFUsuario;
    public TMP_InputField IFContraseña;
    public GameObject entrar;

    public void continuar()
    {
        panel.SetActive(false);
        entrar.SetActive(true);
        IFUsuario.Select();
        IFUsuario.text = "";

        IFContraseña.Select();
        IFContraseña.text = "";


    }
}
