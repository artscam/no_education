using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrinderCheckpoint : MonoBehaviour
{
    public GameObject GrinderEntry;
    private void OnTriggerEnter(Collider other)
    {
    if (other.gameObject == GrinderEntry)
        {
            Debug.Log("Entered");
        }      
    }
}
