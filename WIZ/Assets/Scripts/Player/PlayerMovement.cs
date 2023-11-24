using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;
    Camera cam;

    public float moveSpeed = 6f;
    public float turnSmoothTime = 0.1f;

    private float turnSmoothVelocity;
    private Vector3 direction;

    public bool isFocused;

    public Vector3 cursorPos;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1)) // Focusing Input
        {
            isFocused = true;
        }
        else isFocused = false;

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horizontal, 0f, vertical).normalized;

        //MOVING
        if (direction.magnitude >= 0.1f)
        {
            controller.Move(direction.normalized * moveSpeed * Time.deltaTime);
        }

        //ROTATING
        if (isFocused)
        {
            Vector3 lastCursorPos = Vector3.zero;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            int layer_mask = LayerMask.GetMask("Ground");
            if (Physics.Raycast(ray, out hit, layer_mask))
            {

                cursorPos = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                lastCursorPos = cursorPos;
                //rotate towards point when left mouse held.
                transform.LookAt(cursorPos);
            }
            else
            {
                cursorPos = lastCursorPos;
            }


        }
        else
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

        }

    }
}
