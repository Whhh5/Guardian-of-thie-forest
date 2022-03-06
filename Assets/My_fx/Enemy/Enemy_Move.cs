using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Move : MonoBehaviour
{
    NavMeshAgent nav;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tr = player.position;
        //nav.SetDestination(player.position);
    }
}
