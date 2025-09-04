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
    public UnityEvent uponEscape;
    public float freedomDrive;
    private NavMeshAgent agent;
    private Vector3 target;
    private GameObject FireCircle;
    Rigidbody rb;
    private GameController _gameController;
    private void Awake()
    {
        _gameController = FindObjectOfType<GameController>();
    }
    private void OnEnable()
    {
        EventManager.Guitar2 += EventManager_Guitar2;
        EventManager.DestroyGuitar2 += EventManager_DestroyGuitar2;
    }

    private void OnDisable()
    {
        EventManager.Guitar2 -= EventManager_Guitar2;
        EventManager.DestroyGuitar2 -= EventManager_DestroyGuitar2;
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
    public GameObject EscapeTrigger;
    private void OnTriggerEnter(Collider other)
    {   
        if (other.gameObject == GrinderEntry)
        {
            uponDeath.Invoke();
            IntoTheAbyss();            
        }
        if (other.gameObject == FireCircle)
        {
            
        }
        if (other.gameObject == EscapeTrigger)
        {
            Debug.Log("triggering student escape");
            uponEscape.Invoke();
            StudentEscape();
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
        _gameController.AddScore();
    }

    public void AllocateCorruptScore()
    {
        _gameController.AddCorruptScore();
    }
    private void EventManager_Guitar2()
    {
        FireCircle = GameObject.FindGameObjectWithTag("FireCircle");
        float fireDistance = Vector3.Magnitude(transform.position - FireCircle.transform.position);
        if (fireDistance < 4f | freedomDrive > Random.Range(0.1f,1f))
        {
            if (agent.isActiveAndEnabled)
                agent.SetDestination(FireCircle.transform.position);
        }
        
    }
    private void EventManager_DestroyGuitar2()
    {
        if (agent.isActiveAndEnabled)
            agent.SetDestination(target);
    }

    private void StudentEscape()
    {
        // deactivate nav agent and jump to freedom
        agent.enabled = false;
        GetComponent<MeshCollider>().enabled = false;

        Vector3 freedomVector;
        freedomVector = new Vector3(Random.Range(-1f, 1f), 3, 3);

        rb.isKinematic = false;
        Vector3 studentHead = transform.position + new Vector3(0, 0.1f, 0);
        rb.AddForceAtPosition(freedomVector.normalized * 300, studentHead, ForceMode.Force);
        Destroy(gameObject, 2);
    }
}
