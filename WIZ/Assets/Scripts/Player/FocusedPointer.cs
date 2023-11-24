using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusedPointer : MonoBehaviour
{

    public PlayerMovement pm; // pm has reference to isFocused bool.
    bool showPointer = false;

    public GameObject gfx;

    // Start is called before the first frame update
    void Start()
    {
        gfx.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (pm.isFocused)
        {
            showPointer = true;
        }
        else showPointer = false;

        if (showPointer)
        {
            transform.position = new Vector3(pm.cursorPos.x, 0.2f, pm.cursorPos.z);
            gfx.SetActive(true);
        }
        else gfx.SetActive(false);
    }
}
