using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GuitarController : MonoBehaviour
{
    public GameObject Fire;
    private GameObject newFire;
    public Transform orientation;
    private Vector3 newPos;
    public UnityEvent Guitar_1;
    private bool isPaused = false;
    public float cooldown = 1.5f;
    private bool disableGuitar = false;
    [Header("Cooldown tooltip")]
    [SerializeField] Image tooltip;
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
        if (!isPaused & !disableGuitar)
        {
            if (Input.GetMouseButtonDown(0))
            {
                disableGuitar = true;
                Guitar_1.Invoke();
                SpawnFire();
                StartCoroutine(GuitarCooldown(cooldown, tooltip));
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
    IEnumerator GuitarCooldown(float cooldown, Image UI_image)
    {
        UI_image.fillAmount = 1f;
        UI_image.gameObject.SetActive(true);
        float timer = Time.time + cooldown;
        while (Time.time <= timer)
        {
            UI_image.fillAmount = (timer - Time.time) / cooldown;
            yield return null;
        }
        UI_image.gameObject.SetActive(false);
        disableGuitar = false;
    }

}
