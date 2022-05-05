using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerController : MonoBehaviour
{
    public LayerMask whatCanBeClickedOn;
    public Vector2 mouseClickedPosition;
    private NavMeshAgent myAgent;
    public DestinationImageSpawner destinationImageSpawner;

    private void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }

    public void MoveOnClick(Vector2 mouseClickedPosition)
    {
        RaycastHit raycastHit;
        Ray ray = Camera.main.ScreenPointToRay(mouseClickedPosition);
        if (Physics.Raycast(ray, out raycastHit, 100f, whatCanBeClickedOn)) {
            if (raycastHit.transform != null) {
                destinationImageSpawner.HandleDestinationImage(raycastHit);
                myAgent.SetDestination(raycastHit.point);
                StartCoroutine(ReachedDestination());
            }
        }
    }
    private IEnumerator ReachedDestination() {
        bool hasReached = false;
        // Creates a mini update function loop
        while (hasReached == false) { 
            if (!myAgent.pathPending) {
                if (myAgent.remainingDistance <= myAgent.stoppingDistance) {
                    if (!myAgent.hasPath || myAgent.velocity.sqrMagnitude == 0f) {
                        destinationImageSpawner.DestroyImage();
                        hasReached = true;
                        
                    }
                }
            }
            yield return null;
        }        
    }
}
