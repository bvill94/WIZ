using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    NavMeshAgent agent;

    Transform player;

    public float chaseDistance = 3f;

    public float maxHealth = 20f;
    public float currentHealth;

    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        currentHealth = maxHealth;

        //Needs object with player tag in the scene for ai nav to work.
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= chaseDistance)
        {
            agent.SetDestination(player.position);
        }

        if (currentHealth <= 0f)
        {
            Destroy(gameObject);
            Debug.Log(transform.name + " was destroyed.");
        }

    }

    public void HitByPlayer(float dmg)
    {
        currentHealth = currentHealth - dmg;
    }
}
