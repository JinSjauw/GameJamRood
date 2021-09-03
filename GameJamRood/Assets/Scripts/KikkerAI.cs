using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KikkerAI : MonoBehaviour
{
    NavMeshAgent KikkerDestination;

    GameObject MarcoTarget;

    void Start()
    {
        KikkerDestination = GetComponent<NavMeshAgent>();

        MarcoTarget = GameObject.FindGameObjectWithTag("Player");

        KikkerDestination.destination = MarcoTarget.transform.position;
    }
}
