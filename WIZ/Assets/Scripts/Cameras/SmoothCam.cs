using UnityEngine;

public class SmoothCam : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;

    public Vector3 offset;

    void Start()
    {

    }

    void Update()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
