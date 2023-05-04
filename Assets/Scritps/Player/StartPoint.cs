using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    public string startPoint;
    private MoverPersonaje jugador;
    // Start is called before the first frame update
    void Start()
    {
        jugador = FindObjectOfType<MoverPersonaje>();

        if (startPoint == jugador.currentMap)
        {
            jugador.transform.position = this.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
