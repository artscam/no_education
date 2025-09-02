using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Student : MonoBehaviour
{
    public float speed = 5f;
    public GameObject Target; //meat grinder
    public GameObject playerFollow;
    public UnityEvent uponDeath;

    private NavMeshAgent agent;
    private Vector3 target;
    Rigidbody rb;
    private GameController _gameController;
    private void Awake()
    {
        _gameController = FindObjectOfType<GameController>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        // return agent to navmesh if it strays
        if (NavMesh.SamplePosition(transform.position, out NavMeshHit closestHit, 500, 1))
        {
            GetComponent<NavMeshAgent>().Warp(closestHit.position);
        }
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;

        if (agent != null)
        {
            agent.enabled = true;
            agent.speed = speed;
        }

        target = Target.transform.position;
        agent.SetDestination(target);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collided with " + collision.gameObject.name);
    }

    public GameObject GrinderEntry;
    private void OnTriggerEnter(Collider other)
    {   
        if (other.gameObject == GrinderEntry)
        {
            uponDeath.Invoke();
            IntoTheAbyss();            
        }
    }

    private void IntoTheAbyss()
    {
        // deactivate nav agent and jump into the grinder
        agent.enabled = false;
        GetComponent<MeshCollider>().enabled = false;

        Vector3 intoChute;
        intoChute = (target - transform.position);
        intoChute.y = 2f;

        rb.isKinematic = false;
        rb.useGravity = true;
        Vector3 studentHead = transform.position + new Vector3(0, 0.5f, 0);
        rb.AddForceAtPosition(intoChute.normalized * 300, studentHead, ForceMode.Force);
        Destroy(gameObject, 2);
    }

    public void AllocateScore()
    {
        _gameController.AddScore(1);
    }
}
