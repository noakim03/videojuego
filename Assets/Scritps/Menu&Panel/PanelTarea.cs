using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PanelTarea : MonoBehaviour
{
    public TextMeshProUGUI display;
    public TextMeshProUGUI papel;

    public GameObject panelTarea;
    public GameObject puerta;

    private bool estaPausado = false;
    private bool estaDestruido;


    public AudioClip approved;
    public AudioClip denied;

    private AudioSource audioSource;

    [SerializeField] private int cantidadPuntos;

    public static PanelTarea instance;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        GeneratePassword();
        //estaDestruido = (PlayerPrefs.GetInt("estaDestruido") != 0);
        //if (PlayerPrefs.GetInt("estaDestruido", 0) == 1)
        //{
        //    Destroy(puerta);
        //}
        
    }

    // Update is called once per frame
    void Update()
    {
        //PlayerPrefs.SetInt("estaDestruido", estaDestruido ? 1 : 0);

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (estaPausado)
            {
                Regresar();
            }

        }
    }

    
    public void AddNumber(string number)
    {
        // Longitud de contraseña
        if (display.text.Length >= 5)
        {
            return;
        }

        display.text += number;
    }

    // Borrar pantalla del display
    public void EraseDisplay()
    {
        display.text = "";
    }

    private void GeneratePassword()
    {
        papel.text = "";

        for (int i = 0; i < 3; i++)
        {
            int randNumber = UnityEngine.Random.Range(0, 9);
            papel.text += randNumber;
            
        }
        //papel.text + 09;
    }

    public void CheckPassword()
    {
        if (display.text.Equals(papel.text + "09"))
        {
            audioSource.PlayOneShot(approved);
            display.color = Color.green;
            display.text = "Aceptado";
            Destroy(gameObject, 1.0f);

            GameObject tarea = GameObject.Find("task");
            tarea.SetActive(false);

            ControladorPuntos.instance.SumarPuntos(puntos: cantidadPuntos);

            //Destroy(puerta);
            
            Destroy(puerta);
            //estaDestruido = true;
        }
        else
        {
            audioSource.PlayOneShot(denied);
            display.text = "Denegado";
            Invoke(nameof(EraseDisplay), 1.2f);
            
        }
    }


    public void Regresar()   // Click al botón Continuar de la pausa
    {
        Cursor.visible = false;
        panelTarea.SetActive(false);
        GameObject originalGameObject = GameObject.Find("Player");
        GameObject arma = originalGameObject.transform.GetChild(0).gameObject;
        arma.SetActive(true);
        Time.timeScale = 1;
        estaPausado = false;
    }
}
