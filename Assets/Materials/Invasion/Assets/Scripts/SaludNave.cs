using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SaludNave : MonoBehaviour
{
    public int vidas = 3;
    private bool estaMuerto;


    public static SaludNave instance;

    private void Awake()
    {
        instance = this;
    }


    void Update()
    {
        if (vidas == 0 && !estaMuerto)
        {
            estaMuerto = true;
            

        }
    }
}
