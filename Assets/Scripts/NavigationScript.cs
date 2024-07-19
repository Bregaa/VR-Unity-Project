using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR.Interaction.Toolkit;

public class NavigationScript : MonoBehaviour
{
    public Transform player;
    public Transform meat;
    public Animator animator;

    public AudioSource breathingAudioSource;
    public AudioSource angryAudioSource;

    private NavMeshAgent wolf;
    private gateController gateController;

    private Vector3 meatPosition;
    private Vector3 playerPosition;
    private NavMeshHit hitMeat;
    private NavMeshHit hitPlayer;

    private bool gateIsOpened;

    void Start()
    {
        wolf = GetComponent<NavMeshAgent>();
        gateController = GameObject.Find("Fence Gate").GetComponent<gateController>();
        gateIsOpened = false;
    }

    void Update()
    {
        if (!meat.IsDestroyed())
        {
            meatPosition = meat.position;
        }
        playerPosition = player.position;

        if (!meat.IsDestroyed() && NavMesh.SamplePosition(meatPosition, out hitMeat, 1f, NavMesh.AllAreas))    // If there is a navmesh position close (<1) to the meat, then go to the meat
        {
            wolf.stoppingDistance = 1;  // Change the stopping distance so the wolf reaches the meat
            Vector3 closestPointMeat = hitMeat.position;
            wolf.destination = closestPointMeat;
            Debug.DrawLine(meatPosition, closestPointMeat, Color.red);
            animator.SetBool("isMeatDropped", true);    // When the wolf has reached the meat, change the animation
            if (wolf.velocity.magnitude > 0) // If the wolf is moving
            {
                animator.SetBool("isWalking", true);
            }
            else
            {
                animator.SetBool("isWalking", false);
            }
            GameObject.Find("Meat").GetComponent<XRGrabInteractable>().enabled = false;
            if (!gateIsOpened)
            {
                gateIsOpened = true;
                gateController.OpenGate();
            }
            breathingAudioSource.enabled = true;
            angryAudioSource.Stop();
        }
        else   // Otherwise if there is a navmesh position close (<5) to the player, move to the player
        {
            if (NavMesh.SamplePosition(playerPosition, out hitPlayer, 5f, NavMesh.AllAreas))
            {
                Vector3 closestPointPlayer = hitPlayer.position;
                wolf.destination = closestPointPlayer;   // Set the wolf's destination to the closest point on the NavMesh
                Debug.DrawLine(playerPosition, closestPointPlayer, Color.red);
            }

            if (wolf.velocity.magnitude > 0) // If the wolf is moving
            {
                animator.SetBool("isWalking", true);
            }
            else
            {
                animator.SetBool("isWalking", false);
            }
        }
        
    }


}
