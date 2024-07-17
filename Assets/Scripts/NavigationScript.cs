using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationScript : MonoBehaviour
{
    public Transform player;
    public Animator animator;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Vector3 playerPosition = player.position;
        NavMeshHit hit;

        if (NavMesh.SamplePosition(playerPosition, out hit, 5f, NavMesh.AllAreas))
        {
            Vector3 closestPoint = hit.position;
            agent.destination = closestPoint;   // Set the agent's destination to the closest point on the NavMesh
            Debug.DrawLine(player.position, closestPoint, Color.red);
        }

        if (agent.velocity.magnitude > 0) // If the agent is moving
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }


}
