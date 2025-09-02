using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarBarrier : MonoBehaviour
{
    public GameObject Fire;
    private GameObject newFire;
    public Transform orientation;
    private Vector3 newPos;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnFire();
        }
            
        if (Input.GetMouseButtonDown(1))
            Debug.Log("Pressed right-click.");
    }
    private void SpawnFire()
    {
        if (newFire)
        {
            Destroy(newFire);
        }
        newFire = Instantiate(Fire);
        
        newFire.transform.rotation = orientation.rotation;

        newPos = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
        newFire.transform.position = newPos;
    }
}
