using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{

    Rigidbody rb;
    public float damage = 10f;
    public float speed = 10f;
    public float destroyAfter = 5f; // time till destroyed

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        Destroy(gameObject, destroyAfter); // need to check if its hit something too.
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Enemy")
        {
            collision.transform.GetComponent<EnemyController>().HitByPlayer(damage);
            Debug.Log(transform.name + " has hit " + collision.transform.name);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log(transform.name + " has hit " + collision.transform.name);
            Destroy(gameObject);
        }
    }
}
