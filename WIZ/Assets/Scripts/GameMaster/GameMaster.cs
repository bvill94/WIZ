using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public bool hideCursor, lockCursor, confineCursor;

    void Start()
    {
        CursorSetup();
    }

    void Update()
    {

    }


    public void CursorSetup()
    {
        if (hideCursor)
        {
            Cursor.visible = false;
        }
        else Cursor.visible = true;

        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else Cursor.lockState = CursorLockMode.None;

        if (confineCursor)
        {
            Cursor.lockState = CursorLockMode.Confined; ;
        }
        else Cursor.lockState = CursorLockMode.None;
    }

}
