using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 
 * 
 */
public class GuardarPos : MonoBehaviour
{
    public float PosX;
    public float PosY;
  

    public Vector3 posicion;
    void Start()
    {
        CargarDatos();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))    //Presiona la tecla S para guardar
        {
            GuardarDatos();
        }
    }

    public void GuardarDatos()
    {
        PlayerPrefs.SetFloat("PosX", transform.position.x);
        PlayerPrefs.SetFloat("PosY", transform.position.y);

        print("Datos guardados");
    }
    public void CargarDatos()
    {
        PosX = PlayerPrefs.GetFloat("PosX");
        PosY = PlayerPrefs.GetFloat("PosY");

        posicion.x = PosX;
        posicion.y = PosY;

        transform.position = posicion;
        print("Datos cargados");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("GuardarPos"))
        {
            GuardarDatos();
        }
    }   
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("GuardarPos"))
        {
            GuardarDatos();
        }
    }
}
