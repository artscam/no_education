using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarFollow : MonoBehaviour
{
    public Transform playerForward;
    public float speed = 20f;

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, playerForward.rotation, speed * Time.deltaTime);
    }

    public void RockOut()
    {
        // swing the guitar around when using it! listens to guitar_1 and guitar_2
        transform.rotation = Quaternion.Slerp(transform.rotation, Random.rotation, speed * Time.deltaTime*10);
    }
}


