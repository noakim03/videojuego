using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }
 

    public List<string> destroyedObjects = new List<string>();

    public void DestroyObject(ItemPieza obj)
    {
        // Agrega el nombre del objeto a la lista de objetos destruidos
        destroyedObjects.Add(obj.name);
        // Destruye el objeto
        Destroy(obj);
    }

    private void SaveDestroyedObjects()
    {
        // Convierte la lista de nombres de objetos destruidos en una cadena
        string destroyedObjectsString = string.Join(",", destroyedObjects.ToArray());
        // Guarda la cadena en PlayerPrefs
        PlayerPrefs.SetString("DestroyedObjects", destroyedObjectsString);
    }

    private void LoadDestroyedObjects()
    {
        // Obtiene la cadena guardada en PlayerPrefs
        string destroyedObjectsString = PlayerPrefs.GetString("DestroyedObjects", "");
        // Convierte la cadena en una lista de nombres de objetos destruidos
        string[] destroyedObjectsArray = destroyedObjectsString.Split(',');
        foreach (string objName in destroyedObjectsArray)
        {
            // Encuentra el objeto por su nombre y lo destruye
            GameObject obj = GameObject.Find(objName);
            if (obj != null)
            {
                Destroy(obj);
            }
        }
    }

    private void OnDestroy()
    {
        // Guarda la lista de objetos destruidos antes de salir de la escena
        SaveDestroyedObjects();
    }

    private void Start()
    {
        // Carga la lista de objetos destruidos al iniciar la escena
        LoadDestroyedObjects();
    }

}
