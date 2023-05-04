using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    public GameObject task;

    bool playerClose;
    //private bool currentTask = false;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (isTaskActive() && Input.GetKeyDown(KeyCode.E))
        {
            Cursor.visible = true;
            task.SetActive(true);
        }
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerClose = true;
            GameObject originalGameObject = GameObject.Find("Player");
            GameObject arma = originalGameObject.transform.GetChild(0).gameObject;
            arma.SetActive(false);
            //Time.timeScale = 0;

        }
    }
    
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerClose = false;
            GameObject originalGameObject = GameObject.Find("Player");
            GameObject arma = originalGameObject.transform.GetChild(0).gameObject;
            arma.SetActive(true);
            //Time.timeScale = 1;

        }
    }

    private bool isTaskActive()
    {
        return playerClose && GameObject.FindWithTag("Task");
    }


}
