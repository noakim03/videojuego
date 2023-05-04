using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking; //Nueva libreria
using TMPro;
using System;
using UnityEngine.SceneManagement;
using System.Text;


public class Redes : MonoBehaviour
{
    public static Redes instance;

    private void Awake()
    {
        instance = this;    // Apuntador al objeto

    }

    public TMP_InputField IFUsuario;
    public TMP_InputField IFContraseña;
    public TMP_Text panel;
    public GameObject mensaje;
    public GameObject entrar;
    string resultado;
    public bool UpdateComplete;

    public struct DatosUsuario
    {
        public string usuario;
        public string cont;
    }

    public struct Response
    {
        public string codigo;
        public string mensaje;
        
    }

    public struct Partida
    {
        public int idPartida;
    }

    public struct Nivel
    {
        public int nivel;
        public int idPart;
    }

    DatosUsuario datos = new DatosUsuario();

    public Nivel nivel;
    


    public void LoginJSON()
    {
        StartCoroutine(EnviarJSON());
        
    }


    IEnumerator EnviarJSON()
    {
        datos.usuario = IFUsuario.text;
        datos.cont = IFContraseña.text;

        PlayerPrefs.SetString("usuario", datos.usuario);

        WWWForm www = new WWWForm();
        www.AddField("JSONlogin", JsonUtility.ToJson(datos));
        print(JsonUtility.ToJson(datos));


        UnityWebRequest request = UnityWebRequest.Post("http://50.16.66.220:8080/login", www);
        request.SetRequestHeader("Content-type", "application/x-www-form-urlencoded");
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
        
            string responseText = request.downloadHandler.text;
            Debug.Log(responseText);

            Response res = JsonUtility.FromJson<Response>(responseText); //crea una variable de tipo DU y la llena
            
            if(res.codigo == "Correcto")
            {
                yield return StartCoroutine(EnviarFechaIn()); //para que no se cree una partida nueva
                SceneManager.LoadScene("Menu");

            }
            else
            {
                panel.text = res.mensaje;
                mensaje.SetActive(true);
                entrar.SetActive(false);
            }
            
        }
        else
        {
            Debug.Log(request.error);
        }
        request.Dispose();
    }

    //public void FechaInicio()
    //{
    //    StartCoroutine(EnviarFechaIn());
    //}

    IEnumerator EnviarFechaIn()
    {
        //string info = PlayerPrefs.GetString("usuario");
        //print(info);
        WWWForm forma = new WWWForm();
        //forma.AddField("nombre", PlayerPrefs.GetString("usuario"));
        //print(forma);


        UnityWebRequest request = UnityWebRequest.Post("http://50.16.66.220:8080/fechaInicio/" + PlayerPrefs.GetString("usuario"), forma);
        yield return request.SendWebRequest();
        //Cierto tiempo después
        if (request.result == UnityWebRequest.Result.Success)
        {
            //Descarga exitosa
            string responseText = request.downloadHandler.text;
            Debug.Log(responseText);
            Partida res = JsonUtility.FromJson<Partida>(responseText);
            PlayerPrefs.SetInt("idPartida", res.idPartida);


        }
        else
        {
            Debug.Log(request.error);
        }
        request.Dispose();
    }

    public void Nivel1()
    {
        StartCoroutine(EnviarNivel1());
    }

    IEnumerator EnviarNivel1()
    {
        //string info = PlayerPrefs.GetString("usuario");
        //print(info);
        PlayerPrefs.SetInt("nivel1", 1);
        Debug.Log("Nivel: " + PlayerPrefs.GetInt("nivel1"));
        Debug.Log("Partida: " + PlayerPrefs.GetInt("idPartida"));

        WWWForm forma = new WWWForm();
        forma.AddField("nivel", PlayerPrefs.GetInt("nivel1"));
        forma.AddField("idPartida", PlayerPrefs.GetInt("idPartida"));

        byte[] myData = forma.data;
        //forma.AddField("nombre", PlayerPrefs.GetString("usuario"));
        //print(forma);
        UpdateComplete = false;

        string url = string.Format("http://50.16.66.220:8080/nivel/{0}/{1}", PlayerPrefs.GetInt("nivel1"), PlayerPrefs.GetInt("idPartida"));
        UnityWebRequest request = UnityWebRequest.Put(url, myData);

        
        yield return request.SendWebRequest();
        //Cierto tiempo después
        if (request.result == UnityWebRequest.Result.Success)
        {
            //Descarga exitosa
            string responseText = request.downloadHandler.text;
            Debug.Log(responseText);
            UpdateComplete = true;

        }
        else
        {
            Debug.Log(request.error);
        }
        request.Dispose();
    }

    public void Nivel2()
    {
        StartCoroutine(EnviarNivel2());
    }

    IEnumerator EnviarNivel2()
    {

        PlayerPrefs.SetInt("nivel2", 2);
        Debug.Log("Nivel: " + PlayerPrefs.GetInt("nivel2"));
        Debug.Log("Partida: " + PlayerPrefs.GetInt("idPartida"));

        WWWForm forma = new WWWForm();
        forma.AddField("nivel", PlayerPrefs.GetInt("nivel2"));
        forma.AddField("idPartida", PlayerPrefs.GetInt("idPartida"));

        byte[] myData = forma.data;
        //forma.AddField("nombre", PlayerPrefs.GetString("usuario"));
        //print(forma);

        string url = string.Format("http://50.16.66.220:8080/niveldos/{0}/{1}", PlayerPrefs.GetInt("nivel2"), PlayerPrefs.GetInt("idPartida"));
        UnityWebRequest request = UnityWebRequest.Put(url, myData);
        yield return request.SendWebRequest();
        //Cierto tiempo después
        if (request.result == UnityWebRequest.Result.Success)
        {
            //Descarga exitosa
            string responseText = request.downloadHandler.text;
            Debug.Log(responseText);

        }
        else
        {
            Debug.Log(request.error);
        }
        request.Dispose();
    }


    public void puntuacion()
    {
        StartCoroutine(EnviarPuntuacion());
    }

    IEnumerator EnviarPuntuacion()
    {

        PlayerPrefs.GetInt("Puntaje");
        Debug.Log("Puntuacion " + PlayerPrefs.GetInt("Puntaje"));

        WWWForm forma = new WWWForm();
        forma.AddField("puntuacion", PlayerPrefs.GetInt("Puntaje"));
        forma.AddField("idPartida", PlayerPrefs.GetInt("idPartida"));

        byte[] myData = forma.data;
        //forma.AddField("nombre", PlayerPrefs.GetString("usuario"));
        //print(forma);

        string url = string.Format("http://50.16.66.220:8080/puntuacion/{0}/{1}", PlayerPrefs.GetInt("Puntaje"), PlayerPrefs.GetInt("idPartida"));
        UnityWebRequest request = UnityWebRequest.Put(url, myData);
        yield return request.SendWebRequest();
        //Cierto tiempo después
        if (request.result == UnityWebRequest.Result.Success)
        {
            //Descarga exitosa
            string responseText = request.downloadHandler.text;
            Debug.Log(responseText);
            //Response res = JsonUtility.FromJson<Response>(responseText);

            //if (res.codigo == "Correcto")
            //{
            //    yield return StartCoroutine(EnviarEstado()); //para que no se cree una partida nueva
                

            //}
            
            
        }
        else
        {
            Debug.Log(request.error);
        }
        request.Dispose();
    }


    public void estado()
    {
        StartCoroutine(EnviarEstado());
    }

    IEnumerator EnviarEstado()
    {

        PlayerPrefs.SetString("estado", "Terminado");
        WWWForm forma = new WWWForm();
        forma.AddField("estado", PlayerPrefs.GetString("estado"));
        forma.AddField("idPartida", PlayerPrefs.GetInt("idPartida"));
       

        byte[] myData = forma.data;
        //forma.AddField("nombre", PlayerPrefs.GetString("usuario"));
        //print(forma);

        string url = string.Format("http://50.16.66.220:8080/estado/{0}/{1}", PlayerPrefs.GetString("estado"), PlayerPrefs.GetInt("idPartida"));
        UnityWebRequest request = UnityWebRequest.Put(url, myData);
        yield return request.SendWebRequest();
        //Cierto tiempo después
        if (request.result == UnityWebRequest.Result.Success)
        {
            //Descarga exitosa
            string responseText = request.downloadHandler.text;
            Debug.Log(responseText);

            //Response res = JsonUtility.FromJson<Response>(responseText);

            //if (res.codigo == "Correcto")
            //{
            //    yield return StartCoroutine(EnviarhoraFin()); //para que no se cree una partida nueva


            //}
            
        }
        else
        {
            Debug.Log(request.error);
        }
        request.Dispose();
    }


    public void horaFinal()
    {
        StartCoroutine(EnviarhoraFin());
    }

    IEnumerator EnviarhoraFin()
    {
        WWWForm forma = new WWWForm();
        forma.AddField("idPartida", PlayerPrefs.GetInt("idPartida"));

        byte[] myData = forma.data;


        string url = string.Format("http://50.16.66.220:8080/horaFinal/{0}", PlayerPrefs.GetInt("idPartida"));
        UnityWebRequest request = UnityWebRequest.Put(url, myData);
        yield return request.SendWebRequest();
        //Cierto tiempo después
        if (request.result == UnityWebRequest.Result.Success)
        {
            //Descarga exitosa
            string responseText = request.downloadHandler.text;
            Debug.Log(responseText);


        }
        else
        {
            Debug.Log(request.error);
        }
        request.Dispose();
    }



}
