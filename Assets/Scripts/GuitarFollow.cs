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
}

