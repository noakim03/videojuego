using UnityEngine;

public class Perseguir : MonoBehaviour
{
    Vector2 EnemigoPos;
    Transform Player;
    bool perseguir;
    public int vel;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        if (perseguir)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, vel * Time.deltaTime);
        }
        if (Vector2.Distance(transform.position, EnemigoPos) > 4f)
        {
            perseguir = false;
        }
        FlipSprite();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EnemigoPos = Player.transform.position;
            perseguir = true;
        }
    }

    void FlipSprite()
    {
        if (Player.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (Player.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);

        }
    }
}
