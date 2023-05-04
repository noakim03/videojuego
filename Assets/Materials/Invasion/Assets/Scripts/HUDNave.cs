using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDNave : MonoBehaviour
{

    public static HUDNave instance;

    public Image Vida1;
    public Image Vida2;
    public Image Vida3;

    private void Awake()
    {
        instance = this;
    }  

    internal void ActualizarVidas()
    {
        int vidas = SaludNave.instance.vidas;

        if (vidas == 0)
        {
            Vida1.enabled = false;
        }else if(vidas==1)
        {
            Vida2.enabled = false;
        }else if (vidas == 2)
        {
            Vida3.enabled=false;
        }
    }
}
