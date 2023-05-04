using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ControladorPuntos : MonoBehaviour
{
    public static ControladorPuntos instance;
    [SerializeField] public int score;
    [SerializeField] private int highScore;

    public TMP_Text contadorPuntos;

    //public void LoadGame()
    //{
    //    highScore = PlayerPrefs.GetInt("PuntajeMax", 0);
    //}

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        //if (ControladorPuntos.instance == null)
        //{
        //    ControladorPuntos.instance = this;
        //    DontDestroyOnLoad(this.gameObject);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
    }


    private void Start()
    {
        //highScore = PlayerPrefs.GetInt("PuntajeMax", 0);
        score = PlayerPrefs.GetInt("Puntaje", 0);
        contadorPuntos.text = "Puntos: " + score.ToString(); // Pantalla


        //score = 0;
        print("valor actual"+ score.ToString());

    }


    public void SumarPuntos(int puntos)
    {
        score += puntos;
        print("Score"+score.ToString());

        PlayerPrefs.SetInt("Puntaje", score);
        PlayerPrefs.Save();

        //PlayerPrefs.SetInt("PuntajeMax", highScore);

        //if (score > highScore)
        //{
        //    highScore = score;
        //    PlayerPrefs.SetInt("PuntajeMax", highScore);
        //    PlayerPrefs.Save();
        //    print("Guardar");
        //}
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
    }
}
