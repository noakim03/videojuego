using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public void MostrarMouse()
    {
        Cursor.visible = true;
        //Cursor.lockState = CursorLockMode.None;
    }

    public void EsconderMouse()
    {
        Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
    }
}
