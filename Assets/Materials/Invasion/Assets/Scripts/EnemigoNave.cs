using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemigoNave : MonoBehaviour
{

    public float speed = 10.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    public GameObject explosionPrefab;

    public GameObject puerta;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SaludNave.instance.vidas--;
            GameObject explosion = Instantiate(explosionPrefab, other.transform.position, Quaternion.identity);
            HUDNave.instance.ActualizarVidas();
            Destroy(gameObject);
            Destroy(explosion, 2f);

            if (SaludNave.instance.vidas == 0)
            {
                Destroy(other.gameObject, 1f);
                
                //Regresar como estaba antes...
                //SceneManager.UnloadSceneAsync("Scenes/Juego");
                //SceneManager.UnloadSceneAsync(3);

                SceneManager.LoadScene("TechCity");
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -screenBounds.y*2)
        {
            Destroy(this.gameObject);
        }
    }
}
 