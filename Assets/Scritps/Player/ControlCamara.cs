using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

/**
  * Autor: Noh ah Kim Kwon
  * Seguir al jugador con cinemachine virtual camera (en un nueva escena)
 */

public class ControlCamara : MonoBehaviour
{
    private CinemachineVirtualCamera camara;

    public GameObject jugador;


    public void Awake()
    {
        camara = GetComponent<CinemachineVirtualCamera>();
    }

    void Start()
    {
        jugador = GameObject.Find("Player");
        camara.Follow = jugador.transform;
    }

}
