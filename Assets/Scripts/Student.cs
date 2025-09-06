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
    public Transform hinterland;
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
            GetComponent<NavMeshAgent>().Warp(closestHit.position);

        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;

        if (agent != null)
        {
            agent.enabled = true;
            agent.speed = speed;
        }

        target = Target.transform.position;
        agent.SetDestination(target);
        // if fireceircle exists already head there
        if (GameObject.FindGameObjectWithTag("FireCircle"))
        {
            EventManager_Guitar2();
        }
    }

    public GameObject GrinderEntry;
    public GameObject EscapeTrigger;
    private void OnTriggerEnter(Collider other)
    {   
        if (other.gameObject == GrinderEntry)
        {
            uponDeath.Invoke();
            IntoTheAbyss();
            EventManager.onStudentDeath();
        }
        if (other.gameObject == EscapeTrigger)
        {
            uponEscape.Invoke();
            StudentEscape();
            EventManager.onStudentEscape();
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
        if (agent.isActiveAndEnabled)
            agent.SetDestination(FireCircle.transform.position);
    }
    private void EventManager_DestroyGuitar2()
    {
        Debug.Log("the fire is out!");
        if (agent.isActiveAndEnabled)
            agent.SetDestination(target);
    }

    private void StudentEscape()
    {
        // run away to designated point and vanish
        agent.SetDestination(hinterland.position);
        agent.speed = 15;
        GetComponent<MeshCollider>().enabled = false;
        Destroy(gameObject, 2);
    }
}
