using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveNLoad : MonoBehaviour
{
    MoverPersonaje player;
    SaludPersonaje playerHP;

    private void Start()
    {
        Cursor.visible = true;
    }
    //private void Awake()
    //{
    //    player = FindObjectOfType<MoverPersonaje>();
    //    playerHP = FindObjectOfType<SaludPersonaje>();
    //}

    //public void GuardarJuego()
    //{
    //    Vector2 playerPos = player.GetPosition();
    //    int playerHealth = playerHP.GetHealth();

    //    PlayerPrefs.SetFloat("posX", playerPos.x);
    //    PlayerPrefs.SetFloat("posY", playerPos.y);
    //    PlayerPrefs.SetInt("vidas", playerHealth);

    //}

    //public void CargarJuego()
    //{
    //    Vector2 playerPos = new Vector2(PlayerPrefs.GetFloat("posX"), PlayerPrefs.GetFloat("posY"));
    //    int playerHealth = PlayerPrefs.GetInt("vidas");

    //    player.SetPosition(playerPos);
    //    playerHP.SetHealth(playerHealth);
    //}
}
