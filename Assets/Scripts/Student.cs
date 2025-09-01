using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Student : MonoBehaviour
{
    public float speed = 5f;
    public GameObject Target;
    private Vector3 target;
    public GameObject playerFollow;
    private NavMeshAgent agent;

    [Header("Ground Check")]
    public float Height;
    public LayerMask whatIsGround;
    bool grounded;
    private float fallVelocity;
    private Vector3 newPosition;
    void Start()
    {
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
    void Update()
    {
        if ((transform.position - target).magnitude < 1f)
        {
            Destroy(gameObject);
        }

        //fall if not on ground
        grounded = Physics.Raycast(transform.position, Vector3.down, Height * 0.5f + 0.2f, whatIsGround);
        if (!grounded)
        {
            newPosition = transform.position;
            fallVelocity += 9.8f * Time.deltaTime;
            newPosition.y -= fallVelocity;
            transform.position = newPosition;
        }
        else
            fallVelocity = 0f;             
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collided with " + collision.gameObject.name);
    }
}
