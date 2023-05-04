using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TareaCables : MonoBehaviour
{
    public int conexionesActuales;

    public void ComprobarVictoria()
    {
        if (conexionesActuales == 5)
        {
            Destroy(this.gameObject, 1f);
            SceneManager.LoadScene("TechCity");

        }
    }
}
