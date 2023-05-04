using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialObjects : MonoBehaviour
{

    private static EssentialObjects _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            PanelTarea.instance.CheckPassword();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    

}
