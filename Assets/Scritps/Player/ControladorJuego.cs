using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * 
 * Referencia: https://www.youtube.com/watch?v=R_Qbn6YqAwM
 */
public class ControladorJuego : MonoBehaviour
{
    public static ControladorJuego instance;

    [SerializeField] private GameObject[] puntosDeControl;
    [SerializeField] private GameObject jugador;    //Prefab del jugador
    
    private int indexPuntosControl;

    private void Awake()
    {
        instance = this;

        if (indexPuntosControl >= puntosDeControl.Length)
        {
            PlayerPrefs.SetInt("puntosIndex", 0);
            indexPuntosControl = 0;
        }

        indexPuntosControl = PlayerPrefs.GetInt("puntosIndex");
        Instantiate(jugador, puntosDeControl[indexPuntosControl].transform.position, Quaternion.identity);
    }

    public void UltimoPuntoControl(GameObject puntoControl)
    {
        for (int i = 0; i < puntosDeControl.Length; i++)
        {
            if (puntosDeControl[i] == puntoControl && i > indexPuntosControl)
            {
                PlayerPrefs.SetInt("puntosIndex", i);
            }
        }
    }


    private void Update()
    {
        if (SaludNave.instance.vidas == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
