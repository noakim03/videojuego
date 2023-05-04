using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class insertaEnemigos : MonoBehaviour
{
    public GameObject enemigoPrefab;
    public float tiempoRespawn = 3.0f;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(hordaEnemigos());
    }

    private void spawnEnemigo()
    {
        GameObject e = Instantiate(enemigoPrefab) as GameObject;
        e.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y*2);
    }

    IEnumerator hordaEnemigos()
    {
        float tiempoRespawnInicial = tiempoRespawn;
        float tiempoTranscurrido = 0f;
        while (true)
        {
            yield return new WaitForSeconds(tiempoRespawn);
            spawnEnemigo();

            tiempoTranscurrido += tiempoRespawn;
            if (tiempoTranscurrido >= 10f)
            {
                if(tiempoRespawn <= 1.0f)
                {
                    tiempoTranscurrido = 0f;
                }
                else
                {
                    tiempoRespawn *= 0.9f;
                    tiempoTranscurrido = 0f;
                }
                
            }

        }
    }

}
