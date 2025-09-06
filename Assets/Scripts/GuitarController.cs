using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GuitarController : MonoBehaviour
{
    public GameObject Fire;
    private GameObject newFire;
    public Transform orientation;
    private Vector3 newPos;
    public UnityEvent Guitar_1;
    private bool isPaused = false;

    private void Start()
    {
        isPaused = true;
    }
    public void TogglePause()
    {
        // call this function from pause menu events onPaused, onUnpaused
        isPaused = !isPaused;
    }
    void Update()
    {
        if (!isPaused)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Guitar_1.Invoke();
                SpawnFire();
            }
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

}
