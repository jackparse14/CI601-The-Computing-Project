using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerFollow : MonoBehaviour
{
    public Transform nextPlayer;
    private NavMeshAgent myAgent;
    public bool isPlayerMoving = false;
    private void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        myAgent.SetDestination(nextPlayer.position);
    }
}