using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{

    public bool isFocused;

    public float coolDown = 2f;
    public bool inCooldown = false;

    public GameObject projectilePrefab;
    public Transform releasePoint;


    // Start is called before the first frame update
    void Start()
    {
        releasePoint = GameObject.Find("ProjectileRelease").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1)) // Focusing Input
        {
            isFocused = true;
        }
        else isFocused = false;


        if (isFocused && Input.GetMouseButtonDown(0) && !inCooldown)
        {

            FireProjectile(projectilePrefab);
            StartCoroutine(StartCooldown(coolDown));
            //Debug.Log("Player used ranged attack!");


        }


    }

    void FireProjectile(GameObject projectile)
    {

        // Fire prefab projectile.
        Instantiate(projectile, releasePoint.position, releasePoint.rotation);

    }

    IEnumerator StartCooldown(float timeToWait)
    {
        float timer = 0;
        while (timer <= timeToWait)
        {
            timer += Time.deltaTime;
            inCooldown = true;
            yield return null;
        }
        inCooldown = false;

    }
}
