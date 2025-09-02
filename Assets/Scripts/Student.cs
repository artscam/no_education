using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Student : MonoBehaviour
{
    public float speed = 5f;
    public GameObject Target; //meat grinder
    private Vector3 target;
    public GameObject playerFollow;
    private NavMeshAgent agent;

    [Header("Ground Check")]
    public float Height;
    public LayerMask whatIsGround;
    bool grounded;
    private float fallVelocity;
    private Vector3 newPosition;
    private bool isToast = false;
    Rigidbody rb;
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

    // Update is called once per frame
    /*void Update()
    {       
        if (isToast)
        {
            Debug.Log("get ground!");
            Vector3 intoChute;
            intoChute = target - transform.position;

            rb.isKinematic = false;            
            rb.AddForce(intoChute.normalized, ForceMode.Force);
            isToast = false;
        }
    }*/
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collided with " + collision.gameObject.name);
    }

    public GameObject GrinderEntry;
    private void OnTriggerEnter(Collider other)
    {
        // deactivate nav agent and jump into the grinder
        if (other.gameObject == GrinderEntry)
        {
            isToast = true;
            Debug.Log("Entered");
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
    }
}
