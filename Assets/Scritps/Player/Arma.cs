using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// Ref: https://www.youtube.com/watch?v=7-8nE9_FwWs

public class Arma : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject crosshairs;
    public GameObject player;
    public GameObject bulletPrefab;
    public GameObject bulletStart;  // Bala

    private AudioSource audioSource;
    public AudioClip disparo;

    public float bulletSpeed = 10.0f;

    [SerializeField] private int daño;


    void Start()
    {
        //mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        audioSource = GetComponent<AudioSource>();

        Cursor.visible = false;

    }


    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        //mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Cursor.visible = false;

        crosshairs.transform.position = new Vector2(mousePos.x, mousePos.y);

        Vector3 rotation = mousePos - player.transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg; //Crear rotación

        player.transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (Input.GetMouseButtonDown(0))
        {
            // Disparar
            audioSource.PlayOneShot(disparo);
            float distance = rotation.magnitude;
            Vector2 direction = rotation / distance;
            direction.Normalize();
            Disparar(direction, rotZ);
        }

    }

    void Disparar(Vector2 direction, float rotZ)
    {
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = bulletStart.transform.position;
        b.transform.rotation = Quaternion.Euler(0, 0, rotZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }

    
}
