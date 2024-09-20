using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAI : MonoBehaviour
{
    public Transform goal;
    NavMeshAgent agent;

    private void Start()
    {
         agent = GetComponent<NavMeshAgent>();

    }
    void Update()
    {
        agent.destination = goal.position;
    }
}
