using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{

    public bool isFocused;

    public float damage = 10f;
    public float range = 2f;
    public float coolDown = 2f;
    public bool inCooldown = false;

    public Transform attackOrigin;

    public float attackDuration = 1f;

    bool debugSphere;





    // Start is called before the first frame update
    void Start()
    {
        attackOrigin = GameObject.Find("MeleeAttackOrigin").transform;
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
            StartCoroutine(Attack());
            StartCoroutine(StartCooldown(coolDown));
        }

    }

    IEnumerator Attack()
    {
        float timer = 0;
        while (timer <= attackDuration)
        {
            timer += Time.deltaTime;
            Collider[] hitColliders = Physics.OverlapSphere(attackOrigin.position, range);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.transform.tag == "Enemy")
                {
                    hitCollider.transform.GetComponent<EnemyController>().HitByPlayer(damage);
                    Debug.Log(hitCollider.transform.name + " was hit by melee attack sphere.");
                }
            }

            debugSphere = true;
            yield return null;
        }

        debugSphere = false;
        Debug.Log("Player used melee attack!");

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

    void OnDrawGizmosSelected()
    {
        if (debugSphere)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackOrigin.position, range);
        }


    }
}
