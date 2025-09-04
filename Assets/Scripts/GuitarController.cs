using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GuitarController : MonoBehaviour
{
    public GameObject Fire;
    public GameObject FireCircle;
    private GameObject newFire;
    private GameObject newFire_2;
    public Transform orientation;
    private Vector3 newPos;
    public UnityEvent Guitar_1;
    public UnityEvent Guitar_2;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Guitar_1.Invoke();
            SpawnFire();
        }

        if (Input.GetMouseButtonDown(1))
        {
            SpawnFireCircle();
            EventManager.onGuitar2();
            Guitar_2.Invoke();
        }           

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

    private void SpawnFireCircle()
    {
        if (newFire_2)
        {
            Destroy(newFire_2);
            EventManager.onDestroyGuitar2();
        }
        newFire_2 = Instantiate(FireCircle);

        newPos = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
        newFire_2.transform.position = newPos;
    }

}
